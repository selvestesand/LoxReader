using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using LoxReader.Core;

namespace LoxReader
{

     public class BasePage<VM> : Page
        where VM : BaseViewModel, new()

    {
        #region Private Properties

        private VM viewModel;
            
        #endregion

        #region Public Properties

        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideDownAndFadeInFromTop;

        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.FadeOut;

        public float AnimateSeconds { get; set; } = 0.9f;

        public VM ViewModel
        {
            get { return viewModel; }
            set
            {
                if (value == viewModel)
                    return;

                viewModel = value;
                this.DataContext = viewModel;
            }

        }


        #endregion

        #region Default Constructor

        public BasePage()
        {
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;

            this.Loaded += BasePage_Loaded;

            this.ViewModel = new VM();
        }

        #endregion

        #region Animation Load / Unload        

        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            AnimateIn();
        }

        public async Task AnimateIn()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.None:
                    break;
                case PageAnimation.FadeIn:
                    await this.FadeIn(AnimateSeconds);
                    break;
                case PageAnimation.FadeOut:
                    await this.FadeOut(AnimateSeconds);
                    break;
                case PageAnimation.SlideDownAndFadeInFromTop:
                    await this.SlideAndFadeInFromTop(AnimateSeconds);
                    break;
                case PageAnimation.SlideDownAndFadeOutBottom:
                    await this.SlideAndFadeOutBottom(AnimateSeconds);
                    break;
                default:
                    break;
            }
        }

        public async Task AnimateOut()
        {
            if (this.PageUnloadAnimation == PageAnimation.None)
                return;

                    switch (this.PageUnloadAnimation)
            {
                case PageAnimation.None:
                    break;
                case PageAnimation.FadeIn:
                    await this.FadeIn(AnimateSeconds);
                    break;
                case PageAnimation.FadeOut:
                    await this.FadeOut(AnimateSeconds);
                    break;
                case PageAnimation.SlideDownAndFadeInFromTop:
                    await this.SlideAndFadeInFromTop(AnimateSeconds);
                    break;
                case PageAnimation.SlideDownAndFadeOutBottom:
                    await this.SlideAndFadeOutBottom(AnimateSeconds);
                    break;
                default:
                    break;
            }
        }

        #endregion
        
    }

}
