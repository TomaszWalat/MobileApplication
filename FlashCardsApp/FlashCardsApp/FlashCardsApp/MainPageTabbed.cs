using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FlashCardsApp.View;
using FlashCardsApp.Model;
using FlashCardsApp.ViewModel;

namespace FlashCardsApp
{
    class MainPageTabbed : TabbedPage
    {
        private MainPageModel _model;

        private AllCards _tabOne;
        private AllStacks _tabTwo;

        public MainPageModel Model { get { return _model; } }

        public MainPageTabbed(MainPageModel model)
        {
            _model = model;

            _tabOne = new AllCards(Model.AllCards, Model.AllStacks);
            _tabTwo = new AllStacks(Model.AllStacks, Model.AllCards);

            Title = "Flash Cards";            

            Children.Add(_tabOne);
            Children.Add(_tabTwo);
        }
    }
}
