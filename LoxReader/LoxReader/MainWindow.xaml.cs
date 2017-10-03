using System;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Microsoft.Win32;

namespace LoxReader
{

    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public FindAndReplaceWindow FindAndReplaceWindow;
        public FindWindow FindWindow;
        
        public Handler Handler;

        public MainWindow(string[] args)
        {
            InitializeComponent();
            
            Handler = new Handler();
            Handler.NewFileRead += UpdateTextbox;            

            Handler.FilePath = args.Length > 0
                ? args[0]
                : @"C:\repo\LoxReader\LoxReader\Logs\FFService 2017-05-21.lox";
        }

        private void UpdateTextbox(object sender, HandlerEventArgs e)
        {
            txtBox.Text = e.DecryptedContent;
            txtBox.Focus();
            txtBox.CaretIndex = txtBox.Text.Length;
            txtBox.ScrollToEnd();                     
        }

        private void SearchTextBox(object sender, FindWindow.FindWindowEventArgs e)
        {
            this.Focus();
            int searchIndex = txtBox.Text.Length > txtBox.CaretIndex ? txtBox.CaretIndex + 1  : txtBox.CaretIndex ;
            txtBox.CaretIndex = 
                txtBox.Text.IndexOf(e.SearchString, searchIndex, StringComparison.CurrentCultureIgnoreCase) > 0 
                ? txtBox.Text.IndexOf(e.SearchString, searchIndex, StringComparison.CurrentCultureIgnoreCase) 
                : txtBox.Text.Length;
            txtBox.SelectionStart = txtBox.CaretIndex;
            txtBox.SelectionLength = e.SearchString.Length;
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                var menuItem = e.OriginalSource as MenuItem;
                if(menuItem.Name != null) { 
                    switch (menuItem.Name)
                    {
                        case "Open":
                            OpenFileDialog openFileDialog = new OpenFileDialog();
                            openFileDialog.Multiselect = false;
                            openFileDialog.Filter = "Lox files (*.lox)|*.lox|All files (*.*)|*.*";
                            openFileDialog.InitialDirectory =
                                Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                            Handler.FilePath = openFileDialog.ShowDialog() == true ? openFileDialog.FileName : Handler.FilePath;
                            break;
                        case "Close":
                            Application.Current.Shutdown();
                            break;
                        case "Find":
                            if (FindWindow == null)
                                FindWindow = new FindWindow();
                            FindWindow.Owner = this;
                            FindWindow.Search += SearchTextBox;                                                     
                            FindWindow.Show();
                            break;
                        case "Replace":
                            FindAndReplaceWindow = new FindAndReplaceWindow();
                            break;                    
                        case "About":
                            MessageBox.Show(
                                "LoxReader " + Assembly.GetExecutingAssembly().GetName().Version + " was published on: " +
                                DateTime.Now.ToString("yyyy-MM-dd"), "About");
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (NullReferenceException exception)
            {
                Console.WriteLine(exception);
                MessageBox.Show(exception.Message);                
                throw;
            }
            
        }

    }
}