using FlashCardsApp.Model;
using FlashCardsApp.MVVM;
using FlashCardsApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlashCardsApp.ViewModel
{
    public class StackDetailsViewModel : ViewModelBase
    {
        private ObservableCollection<CardModel> _allCards;
        private ObservableCollection<StackModel> _allStacks;

        private CardModel _selectedItem;

        public StackModel Model { get; private set; }

        public ICommand EditStackCardsCommand { get; protected set; }
        public ICommand PlayFlashcardsCommand { get; protected set; }

        public CardModel SelectedItem
        {
            set
            {
                if(_selectedItem == value) return;
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public StackDetailsViewModel(StackModel model, ObservableCollection<CardModel> allCards, ObservableCollection<StackModel> allStacks)
        {
            Model = model;

            _allCards = allCards;
            _allStacks = allStacks;

            EditCommand = new Command(execute: () => GoToStackEditor());

            EditStackCardsCommand = new Command(execute: () => GoToStackCards());

            PlayFlashcardsCommand = new Command(execute: () => GoToPlayFlashcards());
        }

        public async void GoToCardDetails(int itemIndex)
        {
            CardModel model = Model.Cards[itemIndex];

            CardDetailsViewModel viewModel = new CardDetailsViewModel(model, _allStacks, _allCards);

            CardDetails view = new CardDetails(viewModel);

            SelectedItem = null;

            await Navigation.PushAsync(view);
        }

        public async void GoToStackEditor()
        {
            StackEditorViewModel viewModel = new StackEditorViewModel(Model);

            StackEditor view = new StackEditor(viewModel);

            await Navigation.PushAsync(view);
        }

        public async void GoToStackCards()
        {
            StackCardsViewModel viewModel = new StackCardsViewModel(Model, _allCards);

            StackCards view = new StackCards(viewModel);

            await Navigation.PushAsync(view);
        }

        public async void GoToPlayFlashcards()
        {
            //Console.WriteLine("Still not broken 1");

            PlayFlashcardsViewModel viewModel = new PlayFlashcardsViewModel(Model);
            //Console.WriteLine("Still not broken 2");

            PlayFlashcards view = new PlayFlashcards(viewModel);
            //Console.WriteLine("Still not broken 3");

            await Navigation.PushAsync(view);

            //Console.WriteLine("Still not broken 9");
        }
    }
}
