using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace LoxReader
{
    /// <summary>
    ///     Interaction logic for FindWindow.xaml
    /// </summary>
    public partial class FindWindow : Window
    {
        public delegate void FindNext();

        public FindWindow()
        {
            InitializeComponent();
            findTextBox.Focus();
            directionDown.IsChecked = true;
            Topmost = true;                        
        }

        public event EventHandler<FindWindowEventArgs> Search;

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //OnClose?.Invoke();
            Hide();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            //button.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new FindNext(OnSearch));
            OnSearch();
        }


        private void Window_Closing(object sender, CancelEventArgs e)
        {
            //OnClose?.Invoke();
        }

        public void OnSearch()
        {
            Search?.Invoke(this, new FindWindowEventArgs { SearchString = findTextBox.Text});
        }


        public class FindWindowEventArgs : EventArgs
        {
            public string SearchString { get; set; }
        }

        private void findTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
                OnSearch();
        }
    }
}