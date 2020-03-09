using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Binding_5
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ButtonCommand { get; private set; }

        private Model dataModel;

        public ViewModel()
        {
            dataModel = new Model();

            ButtonCommand = new Command(execute: () =>
            {
                dataModel.UserRespond();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WelcomeMessage"));
            });
                
        }

        public string WelcomeMessage => dataModel.WelcomeMessage;
    }
}
