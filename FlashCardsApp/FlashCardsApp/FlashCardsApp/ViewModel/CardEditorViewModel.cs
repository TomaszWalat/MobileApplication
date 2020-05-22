using FlashCardsApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlashCardsApp.ViewModel
{
    public class CardEditorViewModel
    {
        private CardModel _original;
        private CardModel _model;

        public CardModel Model { get; set; }

        public ICommand SaveCommand { get; set; }

        protected INavigation Navigation => Application.Current.MainPage.Navigation;

        public CardEditorViewModel(CardModel model)
        {
            _original = model;

            Model = new CardModel(_original.Question, _original.Answer);

            SaveCommand = new Command(execute: () =>
            {
                _original.Question = Model.Question;
                _original.Answer = Model.Answer;

                Navigation.PopAsync();
            });
        }
    }
}
