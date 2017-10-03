using System;

namespace LoxReader
{
    public class LoxInfo
    {
        private string _fileName;

        public LoxInfo()
        {
            _fileName = string.Empty;
            CaretIndex = int.MinValue;
        }

        public string FileName
        {
            get { return _fileName; }

            set
            {
                if (_fileName != value)
                {
                    _fileName = value;
                    OnNewFile();
                }
            }
        }

        public int CaretIndex { get; set; }
        public event EventHandler NewFile;

        private void OnNewFile()
        {
            NewFile?.Invoke(this, EventArgs.Empty);
        }
    }
}