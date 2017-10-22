using System.Collections.ObjectModel;
using System.Linq;

namespace LoxReader
{

    public class DirectoryStructureViewModel : BaseViewModel
    {
        #region Public Properties
        
        /// <summary>
        /// List of directories on the machine
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        #endregion

        #region Constructor
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public DirectoryStructureViewModel()
        {
            var children = DirectoryStructure.GetLogicalDrives();

            this.Items = new ObservableCollection<DirectoryItemViewModel>(
                children.Select(drive => new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive)));                
        }

        #endregion

    }
}
