using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using MM.MPT.Common;

namespace FileHandler
{
    public class Handler
    {
        public delegate void EventRaiser();
        
        //private SendCommand handlerCommand;
        //public MainWindow window;

        // Regex pattern used to check log threshold
        public string decryptedContent { get; set; }
        private const string _regexPattern =
            @"((\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}.\d{3}) (\[.*\]) (INFO|DEBUG|ERROR) (.*))";

        public event EventRaiser NewFileRead;

        public Handler(LoxInfo LoxInfo)
        {
            decryptedContent = string.Empty;
        }

        public bool IsValid()
        {
            return true;
        }

        public bool OpenFile(string file)
        {
            if (File.Exists(file))
            {
                //_currentFile = file;
                //FlowDocument doc = new FlowDocument();
                //Paragraph para = new Paragraph();
                var str = new StringBuilder();

                var reader = new StreamReader(file);

                string line;

                while ((line = reader.ReadLine()) != null)
                    switch (CheckLogThreshold(line = Crypto.DecryptString(line)))
                    {
                        case "ERROR":
                        case "DEBUG":
                        case "INFO":
                        default:
                            str.AppendLine(line);
                            //para.Inlines.Add((new Run(line)));
                            break;
                    }

                decryptedContent = str.ToString();                
                reader.Close();

                // Fires event to update MainWindow
                NewFileRead?.Invoke();

                return true;
                //return str.ToString();
            }

            return false;
        }

        internal void Click_Undo()
        {
            //window.richTextBox.Undo();
        }

        internal void Click_Redo()
        {
            //window.richTextBox.Redo();
        }


        /// <summary>
        ///     Returns either "INFO", "DEBUG" or "ERROR"
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private string CheckLogThreshold(string line)
        {
            var regex = new Regex(_regexPattern);
            var match = regex.Match(line);

            if (match.Success)
                return match.Groups[4].Value;
            return "INFO";
        }
    }
}