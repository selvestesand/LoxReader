using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LoxReader
{
    /// <summary>
    /// Interaction logic for FindWindow.xaml
    /// </summary>
    public partial class FindWindow : Window
    {
        

        public event EventHandler<FindWindowEventArgs> Search;
        

        public FindWindow()
        {            
            InitializeComponent();
            findTextBox.Focus();
            directionDown.IsChecked = true;           
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //OnClose?.Invoke();
            this.Hide();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            Search?.Invoke(this, new FindWindowEventArgs() {SearchString = findTextBox.Text});

        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //OnClose?.Invoke();
        }


        public class FindWindowEventArgs : EventArgs
        {
            public string SearchString { get; set; }    
        }
    }
}
