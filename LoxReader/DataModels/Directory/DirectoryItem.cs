
using System.Collections.ObjectModel;
using System.IO;

namespace LoxReader
{
    /// <summary>
    /// Information about a directory item, such as a drive, a file or a folder
    /// </summary>
    public class DirectoryItem
    {
        #region Public Properties

        /// <summary>
        /// The type of this directory item
        /// </summary>
        public DirectoryItemType Type { get; set; }

        /// <summary>
        /// The full path of this directory item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// The name to show in the UI
        /// </summary>
        public string Name => this.Type == DirectoryItemType.Drive ? FullPath :  DirectoryStructure.GetFileFolderName(FullPath);

        /// <summary>
        /// Holds the subitems of this directory
        /// </summary>
        public ObservableCollection<DirectoryItem> Items { get; set; }        

        #endregion


        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DirectoryItem()
        {
            Items = new ObservableCollection<DirectoryItem>();            
        }

        #endregion

    }
}
