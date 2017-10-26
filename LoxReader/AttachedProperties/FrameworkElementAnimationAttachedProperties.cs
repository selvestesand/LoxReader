using System.Windows;

namespace LoxReader
{

    /// <summary>
    /// A base class to run any animation method when a boolean is set to true
    /// and a reverse animation when set to false
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public abstract class AnimateBaseProperty<Parent> : BaseAttachedProperty<Parent, bool>
        where Parent : BaseAttachedProperty<Parent, bool>, new()
    {
        #region Public Properties

        public bool FirstLoad { get; set; } = true;

        #endregion

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            // Get the framework element
            if (!(sender is FrameworkElement element))
                return;

            // Don't fire if the value doesn't change
            if (sender.GetValue(ValueProperty) == value && !FirstLoad)
                return;

            // On first load
            if (FirstLoad)
            {
                RoutedEventHandler onLoaded = null;
                onLoaded = (ss, ee) =>
                {
                    element.Loaded += onLoaded;

                    DoAnimation(element, (bool) value);

                    FirstLoad = false;
                };

                element.Loaded += onLoaded;
            }
            else
                DoAnimation(element, (bool) value);


        }

        protected virtual void DoAnimation(FrameworkElement element, bool value) { }
        
    }

    /// <summary>
    /// Animated a framework element sliding it in from the left
    /// </summary>
    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                await element.SlideInFromLeftAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
            else
                await element.SlideOutToLeftAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
        }

    }
}
