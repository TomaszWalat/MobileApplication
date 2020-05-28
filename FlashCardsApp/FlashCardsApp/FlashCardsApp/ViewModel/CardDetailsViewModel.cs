using FlashCardsApp.Model;
using FlashCardsApp.MVVM;
using FlashCardsApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlashCardsApp.ViewModel
{
    public class CardDetailsViewModel : ViewModelBase
    {
        private ObservableCollection<StackModel> _allStacks;
        private ObservableCollection<CardModel> _allCards;

        private StackModel _selectedItem;

        public CardModel Model { get; private set; }

        public ICommand EditCardStacksCommand { get; protected set; }

        public StackModel SelectedItem
        {
            set
            {
                if (_selectedItem == value) return;
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public CardDetailsViewModel(CardModel model, ObservableCollection<StackModel> allStacks, ObservableCollection<CardModel> allCards)
        {
            Model = model;

            _allStacks = allStacks;
            _allCards = allCards;

            //EditCommand = new Command<CardModel>(execute: (c) => GoToCardEditor(c));
            EditCommand = new Command(execute: () => GoToCardEditor());

            EditCardStacksCommand = new Command(execute: () => GoToCardStacks());
        }

        public async void GoToStackDetails(int itemIndex)
        {
            StackModel model = Model.Stacks[itemIndex];

            StackDetailsViewModel viewModel = new StackDetailsViewModel(model, _allCards, _allStacks);

            StackDetails view = new StackDetails(viewModel);

            SelectedItem = null;

            await Navigation.PushAsync(view);
        }

        public async void GoToCardEditor()
        {
            CardEditorViewModel viewModel = new CardEditorViewModel(Model);

            CardEditor view = new CardEditor(viewModel);

            await Navigation.PushAsync(view);
        }

        public async void GoToCardStacks()
        {
            CardStacksViewModel viewModel = new CardStacksViewModel(Model, _allStacks);

            CardStacks view = new CardStacks(viewModel);

            await Navigation.PushAsync(view);
        }
    }
}
