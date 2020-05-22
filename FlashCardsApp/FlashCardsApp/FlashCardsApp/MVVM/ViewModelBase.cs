using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlashCardsApp.MVVM
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddCommand { get; protected set; }
        public ICommand EditCommand { get; protected set; }
        public ICommand SaveCommand { get; protected set; }
        public ICommand DeleteCommand { get; protected set; }

        protected INavigation Navigation => Application.Current.MainPage.Navigation;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
