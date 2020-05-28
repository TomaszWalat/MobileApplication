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
    public partial class CardDetails : ContentPage
    {
        private CardDetailsViewModel _viewModel;

        public CardDetails(CardDetailsViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            BindingContext = _viewModel;

            CardStacksListView.SelectionMode = ListViewSelectionMode.Single;
            CardStacksListView.ItemTapped += CardStacksListView_ItemTapped;
        }

        private void CardStacksListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            CardStacksListView.SelectedItem = null;
            _viewModel.GoToStackDetails(e.ItemIndex);
        }
    }
}