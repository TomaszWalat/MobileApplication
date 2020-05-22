using FlashCardsApp.Model;
using FlashCardsApp.MVVM;
using FlashCardsApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlashCardsApp.ViewModel
{
    class AllCardsViewModel : ViewModelBase
    {
        private AllCards _view;
        private StackModel _allCards;
        private CardModel _selectedItem;

        //public event PropertyChangedEventHandler PropertyChanged;

        //public ICommand EditCommand { get; private set; }

        //protected INavigation Navigation => Application.Current.MainPage.Navigation;

        public ObservableCollection<CardModel> AllCards
        {
            get { return _allCards.Cards; }
        }

        public CardModel SelectedItem
        {
            set
            {
                if (_selectedItem == value) return;

                _selectedItem = value;
                OnPropertyChanged();
            }
            get => _selectedItem;
        }

        public AllCardsViewModel(AllCards view)
        {
            _view = view;
            _allCards = new StackModel("Cards", "All cards");

            _allCards.Add(new CardModel("1 question", "answer"));
            _allCards.Add(new CardModel("2 question", "answer"));
            _allCards.Add(new CardModel("3 question", "answer"));

            EditCommand = new Command<CardModel>(execute: (c) => GoToCardEditor(c));

        }

        public async void GoToCardDetails(int itemIndex)
        {
            CardModel model = _allCards.Cards[itemIndex];

            CardDetailsViewModel viewModel = new CardDetailsViewModel(model);

            CardDetails view = new CardDetails(viewModel);

            SelectedItem = null;

            await Navigation.PushAsync(view);
        }

        public async void GoToCardEditor(CardModel card)
        {
            CardEditorViewModel viewModel = new CardEditorViewModel(card);

            CardEditor view = new CardEditor(viewModel);

            SelectedItem = null;

            await Navigation.PushAsync(view);
        }


        //private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
