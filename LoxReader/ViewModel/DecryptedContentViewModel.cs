
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Input;

namespace LoxReader
{
    public class DecryptedContentViewModel : BaseViewModel
    {

        #region Private Members

        /// <summary>
        /// Holds the filepath for the current log file
        /// </summary>
        private string filePath;

        #endregion

        #region Public Properties

        /// <summary>
        /// The pages initial height on load
        /// </summary>
        public double PageHeight { get; set; } = 1000;

        /// <summary>
        /// The pages initial height on load
        /// </summary>
        public double PageWidth { get; set; } = 1000;

        /// <summary>
        /// Returns the decrypted content of the encrypted file
        /// </summary>    
        public string DecryptedContent { get; set; }

        /// <summary>
        /// Sets the filepath, which should again trigger a new decrypted content
        /// </summary>
        public string FilePath
        {
            get { return filePath; }

            set
            {
                if (value != filePath)
                {
                    filePath = value;
                    GetDecryptedContent();                    
                }
                    
            }
        }

        #endregion


        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>        
        public DecryptedContentViewModel()
        {            
            this.FilePath = Path.Combine(Directory.GetCurrentDirectory(), @"Logs\", "EPJService 2017-05-21.lox");
        }

        #endregion

        #region Private Helpers

        private async void GetDecryptedContent(){

            
            await Task.Run(() =>
            {
                DecryptedContent = Handler.DecryptFile(FilePath);
            });

        }

        #endregion

    }
}
