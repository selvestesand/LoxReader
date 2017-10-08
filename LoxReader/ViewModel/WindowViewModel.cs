
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Input;

namespace LoxReader
{
    class WindowViewModel : BaseViewModel
    {

        #region Private Members

        /// <summary>
        /// The window using this view model
        /// </summary>
        private Window window;
        
        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        private int outerMarginSize = 10;
        
        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int windowRadius = 2;

        /// <summary>
        /// Holds the filepath for the current log file
        /// </summary>
        private string filePath;

        /// <summary>
        /// Holds the decrypted content for the current log file
        /// </summary>
        private string decryptedString;

        #endregion

        #region Public Properties

        /// <summary>
        /// The windows initial height on load
        /// </summary>
        public double WindowHeight { get; set; } = 1000;

        /// <summary>
        /// The windows initial width on load
        /// </summary>
        public double WindowWidth { get; set; } = 1000;

        /// <summary>
        /// The windows smallest height
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 400;

        /// <summary>
        /// The windows smallest width
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 400;

        /// <summary>
        /// The thickness of the resize border
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        /// <summary>
        /// The thickness of the resize border around the window, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness {get { return new Thickness(ResizeBorder + OuterMarginSize);}}

        /// <summary>
        /// The inner padding of the content
        /// </summary>
        public int InnerContentPadding { get; set; } = 6;

        /// <summary>
        /// The padding of the inner content
        /// </summary>
        public Thickness InnerContentPaddingThickness { get { return new Thickness(InnerContentPadding); } }

        public bool Borderless
        {
            get { return (window.WindowState == WindowState.Maximized); }            
        }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get { return Borderless ? 0 : this.outerMarginSize; }
            set { this.outerMarginSize = value; }
        }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }
    
        /// <summary>
        /// The radius of the edge of the window
        /// </summary>
        public int WindowRadius
        {
            get { return Borderless ? 0 : this.windowRadius; }
            set { this.windowRadius = value;  }
        }

        /// <summary>
        /// The radius of the edge of the window
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); }}

        /// <summary>
        /// The height of the title bar
        /// </summary>
        public int TitleHeight { get; set; } = 38;

        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder);} }

        /// <summary>
        /// Returns the decrypted content of the encrypted file
        /// </summary>
        public string DecryptedContent
        {
            get { return Handler.DecryptFile(filePath) ; }
            private set { decryptedString = value; }
        }

        /// <summary>
        /// Sets the filepath, which should again trigger a new decrypted content
        /// </summary>
        public string FilePath
        {
            get { return filePath; }

            set
            {
                if (value != filePath)
                    filePath = value;
            }
        }


        #endregion

        #region Commands

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to show the system menu of the window
        /// </summary>
        public ICommand MenuCommand { get; set; }


        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="window"></param>
        public WindowViewModel(Window window)
        {
            this.window = window;
            this.decryptedString = string.Empty;
            this.FilePath = Path.Combine(Directory.GetCurrentDirectory(), @"Logs\", "EPJService 2017-05-21.lox");
            //this.FilePath = @"C:\Repository\LoxReader\Logs\EPJService 2017-05-21.lox";

            //Listen out for the window resizing
            this.window.StateChanged += (sender, e) =>
            {
                //Fire off events for all the properties
                OnPropertyChanged(nameof(ResizeBorder));
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            MinimizeCommand = new RelayCommand(() => window.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => window.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(window, GetMousePosition()));

            // Fix window resize issue
            var resizer = new WindowResizer(this.window);
        }

        #endregion

        #region Private Helpers


        /// <summary>
        /// Helper to find current cursor position on screen
        /// </summary>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]

        internal static extern bool GetCursorPos(ref Win32Point pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        }

        public static Point GetMousePosition()
        {
            Win32Point w32Mouse = new Win32Point();
            GetCursorPos(ref w32Mouse);
            return new Point(w32Mouse.X, w32Mouse.Y);
        }
        #endregion

    }
}
