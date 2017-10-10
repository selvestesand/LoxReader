
using System.Collections.ObjectModel;
using System.IO;

namespace LoxReader
{
    public class DirectoryItem
    {
        #region Public Properties

        /// <summary>
        /// Holds the type of this directory item
        /// </summary>
        public DirectoryType Type { get; set; }

        /// <summary>
        /// Holds the full path of this directory item
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Holds the name to show in GUI
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Holds the subitems of this directory
        /// </summary>
        public ObservableCollection<DirectoryItem> Items { get; set; }
        
        public bool CanExpand { get; set; }

        #endregion


        #region Public Methods

        /// <summary>
        /// Adds subitems to this directory item when expanded
        /// </summary>
        public void Expand()
        {
            var subdirectories = Directory.GetDirectories(this.Path);

            foreach (var item in subdirectories)
            {
                
            }


        }

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


        #region Private Helpers

        private string GetDirectoryItemName(string path)
        {
            return string.Empty;
        }

        private string GetDirectoryItemType(string path)
        {
            return string.Empty;
        }

        #endregion

    }
}
