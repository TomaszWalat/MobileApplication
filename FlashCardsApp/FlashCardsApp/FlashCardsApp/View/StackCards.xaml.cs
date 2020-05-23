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
    public partial class StackCards : ContentPage
    {
        private StackCardsViewModel _viewModel;

        public StackCards(StackCardsViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            BindingContext = _viewModel;

        }

        private void PopulateListView()
        {
            //for(int i = 0; i < StackCardsListView)
        }
    }
}