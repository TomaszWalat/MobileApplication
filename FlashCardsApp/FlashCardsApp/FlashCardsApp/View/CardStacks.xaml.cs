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
    public partial class CardStacks : ContentPage
    {
        private CardStacksViewModel _viewModel;

        public CardStacks(CardStacksViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            BindingContext = _viewModel;
        }
    }
}