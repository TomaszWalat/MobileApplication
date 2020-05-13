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
    public partial class AllStacks : ContentPage
    {
        private AllStacksViewModel _viewModel;

        public AllStacks()
        {
            InitializeComponent();

            _viewModel = new AllStacksViewModel(this);
            BindingContext = _viewModel;
        }
    }
}