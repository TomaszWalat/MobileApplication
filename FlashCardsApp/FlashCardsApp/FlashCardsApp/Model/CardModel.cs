using FlashCardsApp.MVVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCardsApp.Model
{
    public class CardModel: ModelBase
    {
        private string _question;
        private string _answer;

        public string Question
        {
            set 
            {
                if (_question != value)
                {
                    _question = value;
                    OnPropertyChanged();
                }
            }
            get { return _question; }
        }

        public string Answer
        {
            set 
            {
                if (_answer != value)
                {
                    _answer = value;
                    OnPropertyChanged();
                }
            }
            get { return _answer;  }
        }

        public CardModel(string question, string answer)
        {
            _question = question;
            _answer = answer;
        }
    }
}
