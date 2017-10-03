using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHandler;
using System.Windows.Input;
using System.ComponentModel;
using Microsoft.Win32;

namespace ViewModel
{
    public class HandlerModel : INotifyPropertyChanged
    {
        private SendCommand handlerCommand;
        private Handler handler = new Handler();

        public event PropertyChangedEventHandler PropertyChanged;

        private string txtBox;
        public string TxtBox
        {
            get
            {
                return txtBox;
            }
            private set
            {
                txtBox = value;
            }
        }

        private string file;
        public string File
        {
            get
            {
                return file;
                
            }
                 set
            {
                file = value;
                OpenFile();
            }
        }
        
        public HandlerModel()
        {
            this.handlerCommand = new SendCommand(OpenFile, handler.IsValid);            
        }
        
        public void OpenFile()
        {
            TxtBox = handler.OpenFile(file);
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("TxtBox"));
            }
        }

        public ICommand OpenClick
        {
            get
            {
                return handlerCommand;
            }
        }


        

    }
}
