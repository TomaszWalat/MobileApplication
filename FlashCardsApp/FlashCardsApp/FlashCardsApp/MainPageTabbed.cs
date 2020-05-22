using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FlashCardsApp.View;
using FlashCardsApp.Model;

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

            _tabOne = new AllCards();
            _tabTwo = new AllStacks(model);

            Title = "Flash Cards";

            //Stack s = new Stack();
            

            //_tabTwo = new AllStacks();
            

            Children.Add(_tabOne);
            Children.Add(_tabTwo);
        }
    }
}
