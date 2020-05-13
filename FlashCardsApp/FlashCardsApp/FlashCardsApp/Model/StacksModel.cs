using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FlashCardsApp.Model
{
    class StacksModel
    {
        private ObservableCollection<StackModel> _stacks;

        public ObservableCollection<StackModel> Stacks
        {
            set { }
            get { return _stacks; }
        }

        public StacksModel()
        {
            _stacks = new ObservableCollection<StackModel>();
        }
    }
}
