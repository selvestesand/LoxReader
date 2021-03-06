﻿using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using MM.MPT.Common;

namespace LoxReader.Core
{
    public static class Handler
    {
        #region Properties    
        //private LoxInfo LoxInfo;
        // Regex pattern used to check log threshold
        //public string DecryptedContent { get; set; }
        private const string RegexPattern =
            @"((\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}.\d{3}) (\[.*\]) (INFO|DEBUG|ERROR) (.*))";
     

        #endregion

        #region Methods
        public static string DecryptFile(string filePath)
        {
            if (!File.Exists(filePath))
                return "";
            
            var str = new StringBuilder();
            var reader = new StreamReader(filePath);
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

            return str.ToString();
            
            // Fires event to update MainWindow
            //OnNewFileRead(str.ToString());

        }

        //private void OnNewFileRead(string decryptedContent)
        //{
          //  NewFileRead?.Invoke(this, new HandlerEventArgs() {DecryptedContent = decryptedContent});
        //}

        /// <summary>
        /// Returns either "INFO", "DEBUG" or "ERROR"
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static string CheckLogThreshold(string line)
        {
            var regex = new Regex(RegexPattern);
            var match = regex.Match(line);

            return match.Success ? match.Groups[4].Value : "INFO";            
        }
    }

    #endregion

    #region HandlerEventArgs

    public class HandlerEventArgs : EventArgs
    {
        public string DecryptedContent { get; set; }    
    }

    #endregion
}