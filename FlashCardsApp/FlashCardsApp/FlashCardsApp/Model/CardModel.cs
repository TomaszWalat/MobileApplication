using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCardsApp.Model
{
    public class CardModel
    {
        private string _question;
        private string _answer;

        public string Question
        {
            set { 
            
            }
            get { return _question; }
        }

        public string Answer
        {
            set { 
            
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
