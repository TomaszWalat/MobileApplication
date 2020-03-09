using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Binding_2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Model dataModel = new Model();

        public MainPage()
        {
            InitializeComponent();

            //ToggleSwitch.BindingContext = dataModel;
            //MessageButton.BindingContext = dataModel;
            MessageLabel.BindingContext = dataModel;

            //ToggleSwitch.SetBinding(Switch.IsToggledProperty, "IsTrue", BindingMode.OneWayToSource);
            //MessageButton.SetBinding(Button.IsEnabledProperty, "IsTrue", BindingMode.OneWay);
            //MessageLabel.SetBinding(Label.IsVisibleProperty, "IsTrue", BindingMode.OneWay);
            //MessageLabel.SetBinding(Label.TextProperty, "CurrentSaying", BindingMode.OneWay);


            //MessageLabel.SetBinding(Label.IsVisibleProperty, "IsTrue", BindingMode.OneWay);
            MessageLabel.SetBinding(Label.TextProperty, "NumberAsString", BindingMode.OneWay);
        }

        private void MessageButton_Clicked(object sender, EventArgs e)
        {
            //dataModel.NextMessage();
            dataModel.IncrementCounter();
            Debug.WriteLine("button clicked");
        }
    }
}
