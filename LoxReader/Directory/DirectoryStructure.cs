using System.Collections.ObjectModel;
using System.IO;

namespace LoxReader
{
    public class DirectoryStructure
    {

        public ObservableCollection<DirectoryItem> Items { get; set; }

        public DirectoryStructure()
        {
            
            foreach (var drive in Directory.GetLogicalDrives())
            {
                Items.Add(new DirectoryItem() { Type = DirectoryType.Drive, Name = drive, Path = drive });
            }
        }

    }
}
