using FlashCardsApp.Model;
using FlashCardsApp.MVVM;
using FlashCardsApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FlashCardsApp.ViewModel
{
    public class CardDetailsViewModel : ViewModelBase
    {
        private CardModel _model;

        private string _question;
        private string _answer;

        private CardModel Model
        {
            get; set;
            //get { return _model; }
        }

        public string Question
        {
            //set
            //{
            //    if (_question == value) return;
            //    _question = value;
            //    OnPropertyChanged();
            //}
            //get { return _question; }
            get { return Model.Question; }
        }

        public string Answer
        {
            get
            {
                return Model.Answer;
            }
        }

        //{
        //set
        //{
        //    if (_answer == value) return;
        //    _answer = value;
        //    OnPropertyChanged();
        //}
        //get { return _answer; }
        //}

        public CardDetailsViewModel(CardModel model)
        {
            Model = model;
            //_question = _model.Question;
            //_answer = _model.Answer;

            //EditCommand = new Command<CardModel>(execute: (c) => GoToCardEditor(c));
            EditCommand = new Command(execute: () => GoToCardEditor());
        }


        public async void GoToCardEditor()//CardModel card)
        {
            CardEditorViewModel viewModel = new CardEditorViewModel(Model);

            CardEditor view = new CardEditor(viewModel);

            await Navigation.PushAsync(view);
        }
    }
}
