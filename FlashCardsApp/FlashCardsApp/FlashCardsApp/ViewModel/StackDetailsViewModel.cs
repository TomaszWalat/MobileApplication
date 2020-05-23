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
        private StackModel _model;

        private ObservableCollection<CardModel> _allCards;

        private string _name;
        private string _description;

        private ObservableCollection<CardModel> _cards;

        private CardModel _selectedItem;

        public ICommand EditStackCardsCommand { get; protected set; }

        //public event PropertyChangedEventHandler PropertyChanged;

        //protected INavigation Navigation => Application.Current.MainPage.Navigation;

        public string Name
        {
            set 
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged();
            }
            get => _name;
        }

        public string Description
        {
            set 
            {
                if (_description == value) return;
                _description = value;
                OnPropertyChanged();
            }
            get => _description;
        }

        public ObservableCollection<CardModel> Cards
        {
            get { return _cards; }
        }

        public CardModel SelectedItem
        {
            set
            {
                if(_selectedItem == value) return;
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public StackDetailsViewModel(StackModel model, ObservableCollection<CardModel> allCards)
        {
            _model = model;
            _name = _model.Name;
            _description = _model.Description;
            _cards = _model.Cards;

            _allCards = allCards;

            EditCommand = new Command(execute: () => GoToStackEditor());

            EditStackCardsCommand = new Command(execute: () => GoToStackCards());
        }

        public async void GoToCardDetails(int itemIndex)
        {
            CardModel model = _cards[itemIndex];

            CardDetailsViewModel viewModel = new CardDetailsViewModel(model);

            CardDetails view = new CardDetails(viewModel);

            SelectedItem = null;

            await Navigation.PushAsync(view);
        }

        public async void GoToStackEditor()
        {
            StackEditorViewModel viewModel = new StackEditorViewModel(_model);

            StackEditor view = new StackEditor(viewModel);

            await Navigation.PushAsync(view);
        }

        public async void GoToStackCards()
        {
            StackCardsViewModel viewModel = new StackCardsViewModel(_model, _allCards);

            StackCards view = new StackCards(viewModel);

            await Navigation.PushAsync(view);
        }
    }
}
