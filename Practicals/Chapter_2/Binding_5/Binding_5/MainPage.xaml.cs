using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Binding_5
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();

            viewModel = new ViewModel();

            BindingContext = viewModel;

            MessageLabel.SetBinding(Label.TextProperty, "WelcomeMessage", BindingMode.OneWay);
            MessageButton.SetBinding(Button.CommandProperty, "ButtonCommand");
        }
    }
}
