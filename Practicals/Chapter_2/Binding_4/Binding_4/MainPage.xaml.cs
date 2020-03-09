using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Binding_4
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Model model;

        public MainPage()
        {
            InitializeComponent();

            model = new Model();

            MessageLabel.BindingContext = model;
            MessageLabel.SetBinding(Label.TextProperty, "SliderValue", BindingMode.OneWay);
        }

        private void MessageSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            model.SliderValue = MessageSlider.Value;
        }
    }
}
