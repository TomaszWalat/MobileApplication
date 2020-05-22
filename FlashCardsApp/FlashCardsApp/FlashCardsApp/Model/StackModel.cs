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
                    foreach(CardModel card in Cards)
                    {
                        if(card.Equals(c))
                        {
                            Cards.Remove(card);
                        }
                    }
                }
            }
        }
    }
}
