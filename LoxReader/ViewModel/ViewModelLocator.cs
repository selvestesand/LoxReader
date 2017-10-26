using System.Windows.Media.Animation;
using LoxReader.Core;

namespace LoxReader
{
    public static class ViewModelLocator
    {
        public static ApplicationViewModel Instance = IoC.Get<ApplicationViewModel>();



    }
}
