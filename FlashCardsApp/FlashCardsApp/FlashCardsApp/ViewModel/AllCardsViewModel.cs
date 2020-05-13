using FlashCardsApp.Model;
using FlashCardsApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlashCardsApp.ViewModel
{
    class AllCardsViewModel
    {
        private AllCards _view;
        private StackModel _allCards;

        protected INavigation Navigation => Application.Current.MainPage.Navigation;

        public ObservableCollection<CardModel> AllCards
        {
            get { return _allCards.Cards; }
        }

        public AllCardsViewModel(AllCards view)
        {
            _view = view;
            _allCards = new StackModel("Cards", "All cards ever");

            _allCards.Add(new CardModel("1 question", "answer"));
            _allCards.Add(new CardModel("2 question", "answer"));
            _allCards.Add(new CardModel("3 question", "answer"));

        }

        public async void GoToCardDetails(int itemIndex)
        {
            CardModel model = _allCards.Cards[itemIndex];

            CardDetailsViewModel viewModel = new CardDetailsViewModel(model);

            CardDetails view = new CardDetails(viewModel);

            await Navigation.PushAsync(view);
        }
    }
}
