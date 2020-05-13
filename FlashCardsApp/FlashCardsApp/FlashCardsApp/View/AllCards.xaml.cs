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
    public partial class AllCards : ContentPage
    {
        private AllCardsViewModel _viewModel;

        public AllCards()
        {
            InitializeComponent();

            _viewModel = new AllCardsViewModel(this);
            BindingContext = _viewModel;

            AllCardsListView.SelectionMode = ListViewSelectionMode.Single;
            AllCardsListView.ItemTapped += AllCardsListView_ItemTapped;
        }

        private void AllCardsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            AllCardsListView.SelectedItem = null;
            Console.WriteLine("Item was tapped");
            Console.WriteLine(e.Item.ToString());

            _viewModel.GoToCardDetails(e.ItemIndex);
        }
    }
}