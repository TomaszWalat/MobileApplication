using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FlashCardsApp.Model
{
    public class MainPageModel
    {
        private StackModel _allCards;
        private ObservableCollection<StackModel> _allStacks;

        public ObservableCollection<CardModel> AllCards
        {
            get { return _allCards.Cards; }
        }

        public ObservableCollection<StackModel> AllStacks
        {
            get { return _allStacks; }
        }

        public MainPageModel()
        {
            _allCards = new StackModel("All Cards");
            _allStacks = new ObservableCollection<StackModel>();
        }
    }
}
