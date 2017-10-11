using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace LoxReader
{
    [ValueConversion(typeof(string),typeof(BitmapImage))]
    public class HeaderToBitmapConverter : IValueConverter
    {

        public static HeaderToBitmapConverter Instance = new HeaderToBitmapConverter();
        
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
            string path = (string)value;

            string image = "Harddrive.png";            

            if (!path.Contains("\\"))
                image = "Folder-Closed_2.png";

            return new BitmapImage(new Uri($"pack://application:,,,/Images/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
