using FlashCardsApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCardsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StackDetails : ContentPage
    {
        private StackDetailsViewModel _viewModel;

        public StackDetails(StackDetailsViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            BindingContext = _viewModel;

            StackCardsListView.SelectionMode = ListViewSelectionMode.Single;
            StackCardsListView.ItemTapped += StackCardsListView_ItemTapped;
        }

        private void StackCardsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            StackCardsListView.SelectedItem = null;
            //Console.WriteLine(e.Item.GetType().Name.ToString() + "  ###############################");
            _viewModel.GoToCardDetails(e.ItemIndex);
        }
    }
}