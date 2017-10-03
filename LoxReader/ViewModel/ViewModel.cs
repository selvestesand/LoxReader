using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using FileHandler;

namespace ViewModel
{
    public class HandlerModel
    {
        private Handler handler;

        private SendCommand command;

        public string file { get; set; }

        public string txtBox
        {
            get { return handler.OpenFile(file); }

            private set { txtBox = value; }
        }

        public void OpenFile()
        {
            txtBox = handler.OpenFile(file);
        }


        public HandlerModel()
        {
            this.handler = new Handler();
            this.command = new SendCommand(this);
            this.file = string.Empty;
        }


    }
}
