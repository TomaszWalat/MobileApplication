using FlashCardsApp.Model;
using FlashCardsApp.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlashCardsApp.ViewModel
{
    public class CardEditorViewModel : ViewModelBase
    {
        private CardModel _original;

        public CardModel Model { get; set; }

        public CardEditorViewModel(CardModel model, ObservableCollection<CardModel> allCards = null)
        {
            _original = model;

            Model = new CardModel(_original.Question, _original.Answer, allCards);

            SaveCommand = new Command(execute: () =>
            {
                if(Model.Question != "" && Model.Answer != "")
                {
                    _original.Question = Model.Question;
                    _original.Answer = Model.Answer;

                    if(allCards != null && !allCards.Contains(model))
                    {
                        allCards.Add(model);
                    }
                }

                Navigation.PopAsync();
            });
        }
    }
}
