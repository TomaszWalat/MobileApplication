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
    public partial class PlayFlashcards : ContentPage
    {
        private PlayFlashcardsViewModel _viewModel;

        public PlayFlashcards(PlayFlashcardsViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Console.WriteLine("Sender is: " + sender.ToString());
            Console.WriteLine("Item is: " + e.ToString());

            //if(e.Item.Equals(_viewModel.CurrentCard))
            //{
                
            //}
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }
    }
}