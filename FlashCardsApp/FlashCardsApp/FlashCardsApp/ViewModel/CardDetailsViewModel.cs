using FlashCardsApp.Model;
using FlashCardsApp.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCardsApp.ViewModel
{
    public class CardDetailsViewModel
    {
        private CardModel _model;

        private string _question;
        private string _answer;

        public string Question
        {
            set { _question = value; }
            get { return _question; }
        }

        public string Answer
        {
            set { _answer = value; }
            get { return _answer; }
        }

        public CardDetailsViewModel(CardModel model)
        {
            _model = model;
            _question = _model.Question;
            _answer = _model.Answer;
        }

    }
}
