using FlashCardsApp.Model;
using FlashCardsApp.MVVM;
using FlashCardsApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FlashCardsApp.ViewModel
{
    class AllStacksViewModel : ViewModelBase
    {
        private AllStacks _view;
        private ObservableCollection<StackModel> _allStacks;
        private StackModel _selectedItem;
        private MainPageModel _mainPageModel;

        //protected INavigation Navigation => Application.Current.MainPage.Navigation;

        public ObservableCollection<StackModel> AllStacks
        {
            get { return _allStacks; }
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

        public MainPageModel MainPageModel { get { return _mainPageModel; } }

        public AllStacksViewModel(AllStacks view, MainPageModel model)
        {
            _view = view;

            //MainPageTabbed mainPage = (MainPageTabbed)Application.Current.MainPage.Navigation.NavigationStack.Last();

            _mainPageModel = model;

            _allStacks = model.AllStacks;

            StackModel stack = new StackModel("stack 1", "this is the first stack");

            stack.Add(new CardModel("1. question", "answer"));
            stack.Add(new CardModel("2. question", "answer"));
            stack.Add(new CardModel("3. question", "answer"));

            _allStacks.Add(stack);

            AddCommand = new Command(execute: () => {
                
                StackModel s = new StackModel("");

                Console.WriteLine("pre stack editor 1------------------------");

                Console.WriteLine("stack name is: " + s.Name);

                GoToStackEditor(s);

                Console.WriteLine("post stack editor 3--------------------------");

                Console.WriteLine("stack name is: " + s.Name);
            });

            EditCommand = new Command<StackModel>(execute: (s) => GoToStackEditor(s));
        }

        public async void GoToStackDetails(int itemIndex)
        {
            StackModel model = _allStacks[itemIndex];

            StackDetailsViewModel viewModel = new StackDetailsViewModel(model);

            StackDetails view = new StackDetails(viewModel);

            SelectedItem = null;

            await Navigation.PushAsync(view);
        }

        public async void GoToStackEditor(StackModel stack)
        {

            StackEditorViewModel viewModel = new StackEditorViewModel(stack, _allStacks);

            StackEditor view = new StackEditor(viewModel);

            SelectedItem = null;

            Console.WriteLine("in stack editor 2.1-----------------");

            await Navigation.PushAsync(view);


            Console.WriteLine("in stack editor 2.2-----------------");
        }
    }
}
