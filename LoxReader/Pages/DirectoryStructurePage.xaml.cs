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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoxReader
{
    /// <summary>
    /// Interaction logic for DirectoryPage.xaml
    /// </summary>
    public partial class DirectoryPage : Page
    {
        public DirectoryPage()
        {
            InitializeComponent();
            //DataContext = new DirectoryStructureViewModel();

            var d = new DirectoryStructureViewModel();

            var item1 = d.Items[0];

            d.Items[0].ExpandCommand.Execute(null);

        }
    }
}
