using FlashCardsApp.Model;
using FlashCardsApp.MVVM;
using FlashCardsApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlashCardsApp.ViewModel
{
    class AllStacksViewModel : ViewModelBase
    {
        private AllStacks _view;
        private ObservableCollection<StackModel> _allStacks;
        private ObservableCollection<CardModel> _allCards;
        private StackModel _selectedItem;

        //protected INavigation Navigation => Application.Current.MainPage.Navigation;

        public ObservableCollection<StackModel> AllStacks
        {
            get { return _allStacks; }
        }

        public ObservableCollection<CardModel> AllCards
        {
            get { return _allCards; }
        }

        public StackModel SelectedItem
        {
            set
            {
                if (_selectedItem == value) return;

                _selectedItem = value;
                OnPropertyChanged();
            }
            get => _selectedItem;
        }

        //public MainPageModel MainPageModel { get { return _mainPageModel; } }

        public AllStacksViewModel(AllStacks view, ObservableCollection<StackModel> allStacks, ObservableCollection<CardModel> allCards)
        {
            _view = view;

            //MainPageTabbed mainPage = (MainPageTabbed)Application.Current.MainPage.Navigation.NavigationStack.Last();

            _allStacks = allStacks;
            _allCards = allCards;

            AddCommand = new Command(execute: () => {
                
                StackModel s = new StackModel("", _allStacks);

                //Console.WriteLine("pre stack editor 1------------------------");

                //Console.WriteLine("stack name is: " + s.Name);

                GoToStackEditor(s);

                //Console.WriteLine("post stack editor 3--------------------------");

                //Console.WriteLine("stack name is: " + s.Name);
            });

            EditCommand = new Command<StackModel>(execute: (s) => GoToStackEditor(s));

            DeleteCommand = new Command<StackModel>(execute: async (s) => {
                SelectedItem = null;

                if(await ConfirmDeleteItem())
                {
                    s.RemoveSelf();
                }
            });
        }

        public async void GoToStackDetails(int itemIndex)
        {
            StackModel model = _allStacks[itemIndex];

            StackDetailsViewModel viewModel = new StackDetailsViewModel(model, _allCards, _allStacks);

            StackDetails view = new StackDetails(viewModel);

            SelectedItem = null;

            await Navigation.PushAsync(view);
        }

        public async void GoToStackEditor(StackModel stack)
        {

            StackEditorViewModel viewModel = new StackEditorViewModel(stack, _allStacks);

            StackEditor view = new StackEditor(viewModel);

            SelectedItem = null;

            //Console.WriteLine("in stack editor 2.1-----------------");

            await Navigation.PushAsync(view);


            //Console.WriteLine("in stack editor 2.2-----------------");
        }

        public async Task<bool> ConfirmDeleteItem()
        {
            bool answer = await _view.DisplayAlert("Delete Stack?", "Are you sure you want to delete this stack?", "Confirm", "Cancel");

            return answer;
        }
    }
}
