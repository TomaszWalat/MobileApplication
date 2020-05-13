using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FlashCardsApp.View;

namespace FlashCardsApp
{
    class MainPageTabbed : TabbedPage
    {
        private AllCards _tabOne;
        private AllStacks _tabTwo;

        public MainPageTabbed()
        {
            _tabOne = new AllCards();
            _tabTwo = new AllStacks();

            Title = "Flash Cards";

            //Stack s = new Stack();
            

            //_tabTwo = new AllStacks();
            

            Children.Add(_tabOne);
            Children.Add(_tabTwo);
        }
    }
}
