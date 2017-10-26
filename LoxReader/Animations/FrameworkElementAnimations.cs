
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace LoxReader
{
    public static class FrameworkElementAnimations
    {

        public static async Task SlideInFromLeftAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            var sb = new Storyboard();

            sb.AddSlideFromLeft(seconds, element.ActualWidth, keepMargin: keepMargin);
            sb.AddFadeIn(seconds);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds);
        }

        public static async Task SlideOutToLeftAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            var sb = new Storyboard();

            sb.AddSlideToLeft(seconds, element.ActualWidth, keepMargin: keepMargin);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds);
        }

        public static async Task SlideAndFadeInFromTopAsync(this FrameworkElement element, float seconds = 0.3f)
        {
            var sb = new Storyboard();

            sb.AddSlideFromTop(seconds, element.ActualHeight);
            sb.AddFadeIn(seconds);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds);
        }


        public static async Task SlideAndFadeOutBottomAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            var sb = new Storyboard();

            sb.AddSlideToBottom(seconds, element.ActualHeight, keepMargin: keepMargin);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds);
        }

        public static async Task FadeInAsync(this FrameworkElement element, float seconds = 0.3f)
        {
            var sb = new Storyboard();
            
            sb.AddFadeIn(seconds);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds);
        }

        public static async Task FadeOutAsync(this FrameworkElement element, float seconds = 0.3f)
        {
            var sb = new Storyboard();

            sb.AddFadeOut(seconds);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds);
        }

    }
}
