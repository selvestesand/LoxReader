using System;
using System.Globalization;
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
            var path = (string)value;

            //if (path == null)
                //return null;

            return new BitmapImage(new Uri($"pack://application:,,,/Images/Harddrive.png"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
