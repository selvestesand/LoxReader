
using System;
using System.Diagnostics;
using System.Globalization;
using LoxReader.Core;

namespace LoxReader
{
    class IoCPageConverter : BaseValueConverter<IoCPageConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

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
