using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HierarchyNav
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditDetailsPage : ContentPage
    {
        public EditDetailsPage()
        {
            InitializeComponent();
        }

        private async void EditNameButton_Clicked(object sender, EventArgs e)
        {
            EditName nextPage = new EditName();
            nextPage.BindingContext = this.BindingContext;
            await Navigation.PushAsync(nextPage, true);
        }

        private void EditAgeSlider_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }
    }
}