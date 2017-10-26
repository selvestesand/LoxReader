using System;
using Ninject;

namespace LoxReader.Core
{
    /// <summary>
    /// The IoC container for our application
    /// </summary>
    public static class IoC
    {
        #region Public Properties
        
        /// <summary>
        /// The kernel for our IoC container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        #endregion

        #region Construction

        /// <summary>
        /// Sets up the IoC container, binds all functions required and is ready for use.
        /// NOTE: Must be called as soon as your application starts.
        /// </summary>
        public static void Setup()
        {
            BindViewModels();
        }

        private static void BindViewModels()
        {
            // Binds to a single instance of ApplicationViewModel
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel(){CurrentPage = ApplicationPage.DecryptedContentPage});
        }

        #endregion

        #region Public Helper Methods

        /// <summary>
        /// Helper function
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

        #endregion
    }
}
