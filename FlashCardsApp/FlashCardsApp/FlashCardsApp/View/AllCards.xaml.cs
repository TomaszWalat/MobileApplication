using FlashCardsApp.Model;
using FlashCardsApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCardsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllCards : ContentPage
    {
        private AllCardsViewModel _viewModel;

        public AllCards(ObservableCollection<CardModel> allCards)
        {
            InitializeComponent();

            _viewModel = new AllCardsViewModel(this, allCards);
            BindingContext = _viewModel;

            AllCardsListView.SelectionMode = ListViewSelectionMode.Single;
            AllCardsListView.ItemTapped += AllCardsListView_ItemTapped;
        }

        private void AllCardsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //AllCardsListView.SelectedItem = null;
            //Console.WriteLine(e.Item.GetType().Name.ToString());
            _viewModel.GoToCardDetails(e.ItemIndex);
        }

    }
}