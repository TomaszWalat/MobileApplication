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
            _allStacks = new ObservableCollection<StackModel>();
            _allCards = new StackModel("All Cards", _allStacks);

            StackModel s = new StackModel("Stack 1", _allStacks, "test stack");

            CardModel c1 = new CardModel("Card 1", "test card", _allCards.Cards);
            CardModel c2 = new CardModel("Card 2", "test card", _allCards.Cards);
            CardModel c3 = new CardModel("Card 3", "test card", _allCards.Cards);
            CardModel c4 = new CardModel("Card 4", "test card", _allCards.Cards);
            CardModel c5 = new CardModel("Card 5", "test card", _allCards.Cards);

            s.Cards.Add(c1);
            s.Cards.Add(c2);
            s.Cards.Add(c3);
            s.Cards.Add(c4);
            s.Cards.Add(c5);

            _allCards.Cards.Add(c1);
            _allCards.Cards.Add(c2);
            _allCards.Cards.Add(c3);
            _allCards.Cards.Add(c4);
            _allCards.Cards.Add(c5);

            _allStacks.Add(s);
            _allStacks.Add(new StackModel("Stack 2", _allStacks, "test stack"));
            _allStacks.Add(new StackModel("Stack 3", _allStacks, "test stack"));
            _allStacks.Add(new StackModel("Stack 4", _allStacks, "test stack"));
            _allStacks.Add(new StackModel("Stack 5", _allStacks, "test stack"));
        }
    }
}
