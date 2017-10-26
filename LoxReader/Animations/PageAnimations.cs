
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace LoxReader
{
    public static class PageAnimations
    {

        public static async Task SlideAndFadeInFromTop(this Page page, float seconds)
        {
            var sb = new Storyboard();

            sb.AddSlideFromTop(seconds, page.WindowHeight);
            sb.AddFadeIn(seconds);

            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds);
        }


        public static async Task SlideAndFadeOutBottom(this Page page, float seconds)
        {
            var sb = new Storyboard();

            sb.AddSlideToBottom(seconds, page.WindowHeight);
            sb.AddFadeOut(seconds);

            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds);
        }

        public static async Task FadeIn(this Page page, float seconds)
        {
            var sb = new Storyboard();
            
            sb.AddFadeIn(seconds);

            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds);
        }

        public static async Task FadeOut(this Page page, float seconds)
        {
            var sb = new Storyboard();

            sb.AddFadeOut(seconds);

            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds);
        }

    }
}
