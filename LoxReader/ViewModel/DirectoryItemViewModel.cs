﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace LoxReader
{
    public class DirectoryItemViewModel : BaseViewModel
    {
        #region Public Properties
        
        public DirectoryItemType Type { get; set; }

        public string FullPath { get; set; }

        public string Name => Type == DirectoryItemType.Drive ? FullPath : DirectoryStructure.GetFileFolderName(FullPath);


        public ObservableCollection<DirectoryItemViewModel> Children;

        /// <summary>
        /// Can expand as long as its not a file
        /// </summary>       
        public bool CanExpand
        {
            get
            {
                return this.Type != DirectoryItemType.File;
            }
        }

        /// <summary>
        /// Indicates if the current item is expanded or not
        /// </summary>
        public bool IsExpanded
        {
            get
            {             
                return Children?.Count(f => f != null) > 0;
            }

            set
            {
                // If the UI tells us to expand...
                if (value == true)
                    // Find all children
                    Expand();
                // if the UI tells us to close
                else
                    this.ClearChildren();
            }
        }

        #endregion

        #region Public Commands

        public ICommand ExpandCommand { get; set; }

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="fullPath">The full path of this item</param>
        /// <param name="type">The type of this item</param>
        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            // Set properties
            this.Type = type;
            this.FullPath = fullPath;

            // Create commands
            ExpandCommand = new RelayCommand(Expand);
                        
            this.ClearChildren();
        }

        #region Private Helper

        private void ClearChildren()
        {
            this.Children = new ObservableCollection<DirectoryItemViewModel>();

            if (this.Type != DirectoryItemType.File)
                this.Children.Add(null);
            
                
        }

        private void Expand()
        {
            // You cannot expand a file
            if (this.Type == DirectoryItemType.File)
                return;

            // Find all children
            var children = DirectoryStructure.GetDirectoryContents(this.FullPath);
            this.Children = new ObservableCollection<DirectoryItemViewModel>(
                children.Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));
        }

        #endregion
    }
}