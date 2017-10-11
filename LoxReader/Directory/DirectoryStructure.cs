using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace LoxReader
{
    /// <summary>
    /// A Helper Class to query information about directories
    /// </summary>
    public class DirectoryStructure
    {

        public static List<DirectoryItem> GetLogicalDrives()
        {
            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();
        }
        

        #region Helpers


        /// <summary>
        /// Gets the directorys top-level content
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            #region Get Folders

            var items = new List<DirectoryItem>();
                       
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder } ));
            }
            catch (Exception)
            {

            }

            #endregion

            #region Get Files

            // Creates an array of every subdirectory
            try
            {
                var subfiles = Directory.GetFiles(fullPath);
                if (subfiles.Length > 0)
                    items.AddRange(subfiles.Select( filePath => new DirectoryItem { FullPath = filePath, Type = DirectoryItemType.File }));
            }
            catch (Exception)
            {

            }

            return items;

            #endregion
        }

        public static string GetFileFolderName(string path)
        {
            if (string.IsNullOrEmpty(path)) return string.Empty;

            // Makes sure every slash is a backslash
            path.Replace('/', '\\');

            int lastIndex = path.LastIndexOf('\\');

            return path.Substring(lastIndex + 1);
        }

        #endregion

        #region Constructor

        public DirectoryStructure()
        {


        }

        #endregion

    }
}
