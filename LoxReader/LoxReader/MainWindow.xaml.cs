using System;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using MM.MPT.Common.Enum;
using System.Windows.Threading;
using System.Threading.Tasks;
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
        public LoxInfo LoxInfo;

        public MainWindow(string[] args)
        {
            InitializeComponent();

            LoxInfo = new LoxInfo();
            Handler = new Handler(LoxInfo);
            Handler.NewFileRead += UpdateTextbox;            

            LoxInfo.FileName = args.Length > 0
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
            txtBox.CaretIndex = 
                txtBox.Text.IndexOf(e.SearchString, StringComparison.CurrentCultureIgnoreCase) > 0 
                ? txtBox.Text.IndexOf(e.SearchString, StringComparison.CurrentCultureIgnoreCase) 
                : txtBox.Text.Length;
            txtBox.SelectionStart = txtBox.CaretIndex;
            txtBox.SelectionLength = e.SearchString.Length;        
        }


        private async void MenuItem_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                var menuItem = e.OriginalSource as MenuItem;

                switch (menuItem.Name)
                {
                    case "Open":
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.Multiselect = false;
                        openFileDialog.Filter = "Lox files (*.lox)|*.lox|All files (*.*)|*.*";
                        openFileDialog.InitialDirectory =
                            Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                        LoxInfo.FileName = openFileDialog.ShowDialog() == true ? openFileDialog.FileName : LoxInfo.FileName;
                        break;
                    case "Close":
                        Application.Current.Shutdown();
                        break;
                    case "Find":
                        if (FindWindow == null)
                            FindWindow = new FindWindow();
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
            catch (NullReferenceException exception)
            {
                Console.WriteLine(exception);
                MessageBox.Show(exception.Message);                
                throw;
            }
            
        }
    }
}