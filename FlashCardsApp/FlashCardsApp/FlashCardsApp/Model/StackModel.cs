using FlashCardsApp.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FlashCardsApp.Model
{
    public class StackModel : ModelBase
    {
        private string _name;
        private string _description;

        private ObservableCollection<CardModel> _cards;

        public string Name
        {
            set 
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
            get { return _name; }
        }

        public string Description
        {
            set 
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
            get { return _description; }
        }

        public ObservableCollection<CardModel> Cards
        { 
            get { return _cards; }
        }

        public StackModel(string name, string description = "")
        {
            _name = name;
            _description = description;
            _cards = new ObservableCollection<CardModel>();
        }

        public StackModel(string name, ObservableCollection<CardModel> cards, string description = "")
        {
            _name = name;
            _description = description;
            _cards = cards;
        }

        public void Add(CardModel c)
        {
            if(c != null)
            {
                if(!Cards.Contains(c))
                {
                    Cards.Add(c);
                }
            }
        }

        public void Remove(CardModel c)
        {
            if(c != null)
            {
                if(Cards.Contains(c))
                {
                    for(int i = Cards.Count - 1; i > -1; i--)//CardModel card in Cards)
                    {
                        if(Cards[i].Equals(c))
                        {
                            Cards.RemoveAt(i);
                        }
                    }
                }
            }
        }
    }
}
