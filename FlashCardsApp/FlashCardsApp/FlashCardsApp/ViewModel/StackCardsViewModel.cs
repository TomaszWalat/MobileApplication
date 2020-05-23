using FlashCardsApp.Model;
using FlashCardsApp.MVVM;
using FlashCardsApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace FlashCardsApp.ViewModel
{
    public class StackCardsViewModel : ViewModelBase
    {
        private StackCards _view;
        private StackModel _model;
        private ObservableCollection<CardModel> _allCards;

        private ObservableCollection<CardModel> _tempCards;

        public ObservableCollection<CardModel> AllCards { get { return _allCards; } }

        public string Name { get { return _model.Name; } }

        public ObservableCollection<CardModel> Cards { get { return _model.Cards; } }

        public StackCardsViewModel(/*StackCards view,*/ StackModel model, ObservableCollection<CardModel> allCards)
        {
            //_view = view;
            _model = model;
            _allCards = allCards;

            _tempCards = new ObservableCollection<CardModel>();

            CopyCards(Cards, _tempCards);

            SaveCommand = new Command(execute: () => UpdateStackCards());
        }

        public void CopyCards(ObservableCollection<CardModel> from, ObservableCollection<CardModel> to)
        {
            for(int i = 0; i < from.Count; i++)
            {
                if (!to.Contains(from[i]))
                {
                    to.Add(from[i]);
                }
            }
        }

        public void UpdateTempCards(bool isChecked, CardModel card)
        {
            if(Cards.Contains(card))
            {
                if(!isChecked)
                {
                    _tempCards.Remove(card);
                }
            }
            else
            {
                if(isChecked)
                {
                    _tempCards.Add(card);
                }
            }
        }

        private async void UpdateStackCards()
        {
            CopyCards(_tempCards, Cards);

            for(int i = Cards.Count - 1; i > -1 ; i--)
            {
                if (!_tempCards.Contains(Cards[i]))
                {
                    Cards.RemoveAt(i);
                }
            }

            await Navigation.PopAsync();
        }
    }
}
