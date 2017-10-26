using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using LoxReader.Core;

namespace LoxReader
{
    [ValueConversion(typeof(DirectoryItemType),typeof(BitmapImage))]
    public class DirectoryTypeToBitmapConverter : IValueConverter
    {

        public static DirectoryTypeToBitmapConverter Instance = new DirectoryTypeToBitmapConverter();
        
        /// <summary>
        /// Convert a full path to a specific image type of a drive, folder or file
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            string image = "File.png";

            switch ((DirectoryItemType)value)
            {
                case DirectoryItemType.Drive:
                    image = "Harddrive.png";
                    break;
                case DirectoryItemType.Folder:
                    image = "Folder-Closed.png";                                    
                    break;
                default:
                    break;
            }            

            return new BitmapImage(new Uri($"pack://application:,,,/Images/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
