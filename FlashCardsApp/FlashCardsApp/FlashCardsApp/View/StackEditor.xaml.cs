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
    public partial class StackEditor : ContentPage
    {
        private StackEditorViewModel _viewModel;

        public StackEditor(StackEditorViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            BindingContext = _viewModel;
        }
    }
}