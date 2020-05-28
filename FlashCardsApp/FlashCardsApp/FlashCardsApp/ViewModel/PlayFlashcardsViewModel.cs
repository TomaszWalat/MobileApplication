using FlashCardsApp.Model;
using FlashCardsApp.MVVM;
using FlashCardsApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlashCardsApp.ViewModel
{
    public class PlayFlashcardsViewModel : ViewModelBase
    {
        //private PlayFlashcards _view;
        private StackModel _model;
        //private ObservableCollection<CardModel> _cards;
        private ObservableCollection<CardModel> _playCards;
        private CardModel _currentCard;

        public ICommand CardSwipedRight { get; protected set; }
        public ICommand CardSwipedLeft { get; protected set; }

        public ICommand CardTapped { get; protected set; }

        public ObservableCollection<CardModel> PlayCards
        {
            get { return _playCards; }
        }

        public int Correct { get; private set; }
        public int Incorrect { get; private set; }

        public CardModel CurrentCard
        {
            set
            {
                if (_currentCard == value) return;

                _currentCard = value;
                OnPropertyChanged();
            }
            get => _currentCard;
        }

        public string StackName { get; private set; }

        public PlayFlashcardsViewModel(StackModel model)
        {
            //Console.WriteLine("Still not broken 4");
            //_view = view;
            _model = model;
            //Console.WriteLine("Still not broken 5");
            //_cards = cards;
            //Console.WriteLine("Still not broken 6");
            _playCards = new ObservableCollection<CardModel>();
            //Console.WriteLine("Still not broken 7");
            CopyCards(_model.Cards, _playCards);
            //Console.WriteLine("Still not broken 8");
            StackName = _model.Name;

            Correct = 0;
            Incorrect = 0;

            CardSwipedLeft = new Command(execute: () => SwipeLeft());
            CardSwipedRight = new Command(execute: () => SwipedRight());
            CardTapped = new Command(execute: () => RevealAnswer());

            Console.WriteLine("Play cards viewmodel is ready");
        }

        private void SwipedRight()
        {
            if(CurrentCard != null)
            {
                Correct += 1;
                int cardIndex = _playCards.IndexOf(CurrentCard);
                _playCards.RemoveAt(cardIndex);
                if(_playCards.Count > 0)
                {

                }
            }
        }

        private void SwipeLeft()
        {
            if(CurrentCard != null)
            {
                Incorrect += 1;
                int cardIndex = _playCards.IndexOf(CurrentCard);
                _playCards.RemoveAt(cardIndex);
            }
        }

        private void RevealAnswer()
        {
            Console.WriteLine("Reveal Answer tirggered");
            //if(CurrentCard != null)
            //{
            //    CurrentCard
            //}
        }

        private void CopyCards(ObservableCollection<CardModel> from, ObservableCollection<CardModel> to)
        {
            Console.WriteLine("copying cards");
            for (int i = 0; i < from.Count; i++)
            {
                to.Add(from[i]);
            }
            Console.WriteLine("Finished copying cards");
        }
    }
}
