
using System.ComponentModel;
using PropertyChanged;

namespace LoxReader
{
    [AddINotifyPropertyChangedInterface]
    class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => {};

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
