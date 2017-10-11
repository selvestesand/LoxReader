using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoxReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new WindowViewModel(this);

            foreach (var drive in Directory.GetLogicalDrives())
            {
                var t = new TreeViewItem();

                t.Header = drive;
                t.Tag = drive;

                t.Items.Add(null);

                t.Expanded += Folder_Expanded;

                FolderView.Items.Add(t);

            }

        }

        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem t = (TreeViewItem)sender;
            string path = (string)t.Tag;

            if (t.Items[0] == null || t.Items.Count > 1)
            t.Items.Clear();

            try
            {
                foreach (var directory in Directory.GetDirectories(path))
                {
                    var item = new TreeViewItem();

                    item.Header = GetFolderFromFullPath(directory);
                    item.Tag = directory;

                    item.Items.Add(null);

                    t.Items.Add(item);
                }
            }
            catch (Exception)
            {
                               
            }
            

        }

        private string GetFolderFromFullPath(string fullPath)
        {
            //Makes sure any slashes are backslashes
            fullPath.Replace('/','\\');

            //Finds the last index of \
            int lastIndex = fullPath.LastIndexOf('\\');

            // Returns everything after the last index
            return fullPath.Substring(lastIndex + 1);
        }
    }
}
