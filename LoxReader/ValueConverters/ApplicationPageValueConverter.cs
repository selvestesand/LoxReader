
using System;
using System.Diagnostics;
using System.Globalization;

namespace LoxReader
{
    class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.DirectoryPage:
                    return new DirectoryPage();
                case ApplicationPage.DecryptedContentPage:
                    return new DecryptedContentPage();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
