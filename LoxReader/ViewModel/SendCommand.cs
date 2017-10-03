using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.Win32;

namespace ViewModel
{
    class SendCommand : ICommand
    {

        private HandlerModel model;

        private Action WhattoExecute;
        private Func<bool> WhentoExecute;

        public event EventHandler CanExecuteChanged;

        //public SendCommand(HandlerModel model)
        //{
        //    this.model = model;
        //}

        public SendCommand(Action What, Func<bool> When)
        {
            WhentoExecute = When;
            WhattoExecute = What;
            //stringParam = param;
        }

        public bool CanExecute(object parameter)
        {
            return WhentoExecute();
        }

        public void Execute(object parameter)
        {
            //OpenFileDialog dlg = new OpenFileDialog();
            //dlg.DefaultExt = ".lox";
            //dlg.Filter = "Encrypted log files|*.lox";

            //Nullable<bool> result = dlg.ShowDialog();

            //if (result == true)
            //{
            //    model.File = dlg.FileName;
            //}

            WhattoExecute();

        }
    }
}
