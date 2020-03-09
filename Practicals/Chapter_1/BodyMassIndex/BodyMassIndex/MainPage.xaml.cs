using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BodyMassIndex
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        enum EntrySource
        {
            Weight, Height
        }

        private BmiModel model = new BmiModel();

        public MainPage()
        {
            InitializeComponent();

            BmiLabel.IsVisible = false;
            OutputLabel.IsVisible = false;
            ErrorLabel.Opacity = 0.0;
        }

        private async Task SyncViewAndModelAsync(EntrySource eSrc, string newValueAsString)
        {
            bool successful;// = false;
            string errorString;// = "";

            if(eSrc == EntrySource.Height)
            {
                successful = model.SetHeighttAsString(newValueAsString, out errorString);
                HeightErrorLabel.IsVisible = !successful;
            }
            else
            {
                successful = model.SetWeightAsString(newValueAsString, out errorString);
                WeightErrorLabel.IsVisible = !successful;
            }

            if(model.BmiValue != null)
            {
                BmiLabel.IsVisible = true;
                OutputLabel.IsVisible = true;
                OutputLabel.Text = string.Format("{0:f1}", model.BmiValue);
            }
            else
            {
                BmiLabel.IsVisible = false;
                OutputLabel.IsVisible = false;
            }

            if(!successful)
            {
                await GiveFeedbackAsync(errorString);
            }
        }

        private async Task GiveFeedbackAsync(string errorMessage)
        {
            ErrorLabel.Text = errorMessage;
            await ErrorLabel.FadeTo(1.0, 500);
            await Task.Delay(2000);
            await ErrorLabel.FadeTo(0.0, 500);
        }

        private async void Handle_HeightAsync(object sender, TextChangedEventArgs e)
        {
            await SyncViewAndModelAsync(EntrySource.Height, e.NewTextValue);
        }

        private async void Handle_WeightAsync(object sender, TextChangedEventArgs e)
        {
            await SyncViewAndModelAsync(EntrySource.Weight, e.NewTextValue);
        }
    }
}
