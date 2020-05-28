using FlashCardsApp.Model;
using FlashCardsApp.MVVM;
using FlashCardsApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlashCardsApp.ViewModel
{
    class AllCardsViewModel : ViewModelBase
    {
        private AllCards _view;
        private ObservableCollection<CardModel> _allCards;
        private ObservableCollection<StackModel> _allStacks;
        private CardModel _selectedItem;

        //public event PropertyChangedEventHandler PropertyChanged;

        //public ICommand EditCommand { get; private set; }

        //protected INavigation Navigation => Application.Current.MainPage.Navigation;

        public ObservableCollection<CardModel> AllCards
        {
            get { return _allCards; }
        }

        public ObservableCollection<StackModel> AllStacks
        {
            get { return _allStacks; }
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

        public AllCardsViewModel(AllCards view, ObservableCollection<CardModel> allCards, ObservableCollection<StackModel> allStacks)
        {
            _view = view;
            _allCards = allCards;
            _allStacks = allStacks;

            AddCommand = new Command(execute: () => {

                CardModel c = new CardModel("", "", _allCards);

                GoToCardEditor(c);
            });

            EditCommand = new Command<CardModel>(execute: (c) => GoToCardEditor(c));

            DeleteCommand = new Command<CardModel>(execute: async (c) => {

                SelectedItem = null;

                if (await ConfirmDeleteItem())
                {
                    c.RemoveSelf();
                }
            });

        }

        public async void GoToCardDetails(int itemIndex)
        {
            CardModel model = _allCards[itemIndex];

            CardDetailsViewModel viewModel = new CardDetailsViewModel(model, _allStacks, _allCards);

            CardDetails view = new CardDetails(viewModel);

            SelectedItem = null;

            await Navigation.PushAsync(view);
        }

        public async void GoToCardEditor(CardModel card)
        {
            CardEditorViewModel viewModel = new CardEditorViewModel(card, _allCards);

            CardEditor view = new CardEditor(viewModel);

            SelectedItem = null;

            await Navigation.PushAsync(view);
        }

        public async Task<bool> ConfirmDeleteItem()
        {
            bool answer = await _view.DisplayAlert("Delete Card?", "Are you sure you want to delete this card?", "Confirm", "Cancel");
            
            return answer;
        }
    }
}
