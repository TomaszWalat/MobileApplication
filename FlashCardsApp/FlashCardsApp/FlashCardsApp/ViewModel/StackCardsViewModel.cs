using FlashCardsApp.Model;
using FlashCardsApp.MVVM;
using FlashCardsApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace FlashCardsApp.ViewModel
{
    public class StackCardsViewModel : ViewModelBase
    {
        private StackModel _model;
        private ObservableCollection<CardModel> _allCards;

        private ObservableCollection<CardModel> _tempCards;

        public ObservableCollection<CardModel> AllCards { get { return _allCards; } }

        public ObservableCollection<CardModel> Cards { get { return _model.Cards; } }

        public StackCardsViewModel(StackModel model, ObservableCollection<CardModel> allCards)
        {
            _model = model;
            _allCards = allCards;

            _tempCards = new ObservableCollection<CardModel>();

            CopyCards(Cards, _tempCards);

            SaveCommand = new Command(execute: () => UpdateStackCards(_tempCards));
        }

        private void CopyCards(ObservableCollection<CardModel> from, ObservableCollection<CardModel> to)
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
            Console.WriteLine("Updating in progress");
            if (!isChecked)
            {
                _tempCards.Remove(card);
            }
            else if (isChecked)
            {
                _tempCards.Add(card);
            }

            //if (Cards.Contains(card))
            //{
            //    if (!isChecked)
            //    {
            //        _tempCards.Remove(card);
            //    }
            //}
            //else
            //{
            //    if (isChecked)
            //    {
            //        _tempCards.Add(card);
            //    }
            //}
            Console.WriteLine("Updating done");
        }

        private void SubscribeStackAndCard(CardModel card)
        {
            card.SubscribeObject(_model);
            _model.SubscribeObject(card);
        }

        private void UnsubscribeStackAndCard(CardModel card)
        {
            card.UnsubscribeObject(_model);
            _model.UnsubscribeObject(card);
        }

        private async void UpdateStackCards(ObservableCollection<CardModel> cards)
        {
            Console.WriteLine("Saving initated");
            //CopyCards(_tempCards, Cards);
            //Console.WriteLine("Stack ==================================/n");

            //Console.WriteLine("_tempCount: " + cards.Count);
            //Console.WriteLine("Cards.Count: " + Cards.Count);
            for (int i = 0; i < cards.Count; i++)
            {
                //Console.WriteLine("i is: " + i);

                //cards[i].SubscribeObject(_model);
                //_model.SubscribeObject(cards[i]);
                SubscribeStackAndCard(cards[i]);
            }

            //Console.WriteLine("_tempCount: " + cards.Count);
            //Console.WriteLine("Cards.Count: " + Cards.Count);
            //Console.WriteLine("Stack ----------------------------------/n");

            //Console.WriteLine("_tempCount: " + cards.Count);
            //Console.WriteLine("Cards.Count: " + Cards.Count);
            //int n = 1;
            //Console.WriteLine("n: " + n);

            //CardModel tempCard;

            for (int i = Cards.Count; i > 0 ; i--)
            {
                //Console.WriteLine("i is: " + i);
                //Console.WriteLine("n: " + n);

                if (!cards.Contains(Cards[i - 1]))
                {
                    UnsubscribeStackAndCard(Cards[i - 1]);
                    //tempCard = Cards[i - n];

                    ////Console.WriteLine("1 - Cards.Count: " + Cards.Count);

                    //tempCard.UnsubscribeObject(_model);
                    ////Cards[i - n].ForgetObservable(_model);

                    ////Console.WriteLine("2 - Cards.Count: " + Cards.Count);

                    //_model.UnsubscribeObject(tempCard);
                    ////_model.ForgetObservable(Cards[i - n]);

                    ////Console.WriteLine("3 - Cards.Count: " + Cards.Count);
                    ////n++;
                }
            }

            //Console.WriteLine("Stack ==================================/n");
            //for(int i = 0; i < Cards.Count; i++)
            //{
            //    Cards[i].SubscribeObject(_model);
            //}

            Console.WriteLine("Saving finished");

            await Navigation.PopAsync();
        }
    }
}
