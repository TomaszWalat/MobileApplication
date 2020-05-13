using FlashCardsApp.Model;
using FlashCardsApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FlashCardsApp.ViewModel
{
    class AllStacksViewModel
    {
        private AllStacks _view;
        private ObservableCollection<StackModel> _allStacks;

        public ObservableCollection<StackModel> AllStacks
        {
            get { return _allStacks; }
        }

        public AllStacksViewModel(AllStacks view)
        {
            _view = view;
            _allStacks = new ObservableCollection<StackModel>();

            _allStacks.Add(new StackModel("stack 1", "this is the first stack"));
        }

        
    }
}
