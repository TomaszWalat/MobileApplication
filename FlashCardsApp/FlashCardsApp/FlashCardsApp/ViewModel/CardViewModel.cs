using FlashCardsApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCardsApp.ViewModel
{
    class CardViewModel
    {
        private CardModel _model;

        public CardModel Model
        {
            set { }
            get { return _model; }
        }

        public CardViewModel(CardModel c)
        {
            _model = c;
        }

    }
}
