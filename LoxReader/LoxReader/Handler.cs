using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using MM.MPT.Common;
using MM.MPT.Common.Language;

namespace LoxReader
{
    public class Handler
    {        
        private LoxInfo LoxInfo;
        // Regex pattern used to check log threshold
        public string DecryptedContent { get; set; }
        private const string RegexPattern =
            @"((\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}.\d{3}) (\[.*\]) (INFO|DEBUG|ERROR) (.*))";

        public event EventHandler<HandlerEventArgs> NewFileRead;

        public Handler(LoxInfo loxInfo)
        {
            DecryptedContent = string.Empty;
            LoxInfo = loxInfo;
            LoxInfo.NewFile += OpenFile;
        }

        public bool IsValid()
        {
            return true;
        }

        private void OpenFile(object sender, EventArgs e)
        {
            if (File.Exists(LoxInfo.FileName))
            {
                var str = new StringBuilder();
                var reader = new StreamReader(LoxInfo.FileName);
                string line;

                while ((line = reader.ReadLine()) != null)
                    switch (CheckLogThreshold(line = Crypto.DecryptString(line)))
                    {
                        case "ERROR":
                        case "DEBUG":
                        case "INFO":
                        default:
                            str.AppendLine(line);
                            break;
                    }
              
                reader.Close();

                // Fires event to update MainWindow
                OnNewFileRead(str.ToString());
            }


        }

        private void OnNewFileRead(string decryptedContent)
        {
            NewFileRead?.Invoke(this, new HandlerEventArgs() {DecryptedContent = decryptedContent});
        }

        /// <summary>
        ///     Returns either "INFO", "DEBUG" or "ERROR"
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private string CheckLogThreshold(string line)
        {
            var regex = new Regex(RegexPattern);
            var match = regex.Match(line);

            if (match.Success)
                return match.Groups[4].Value;
            return "INFO";
        }
    }

    public class HandlerEventArgs : EventArgs
    {
        public string DecryptedContent { get; set; }    
    }
}