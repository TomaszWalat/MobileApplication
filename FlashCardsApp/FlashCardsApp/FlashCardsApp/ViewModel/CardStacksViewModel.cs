using FlashCardsApp.Model;
using FlashCardsApp.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace FlashCardsApp.ViewModel
{
    public class CardStacksViewModel : ViewModelBase
    {
        private CardModel _model;

        private ObservableCollection<StackModel> _allStacks;

        private ObservableCollection<StackModel> _tempStacks;

        public ObservableCollection<StackModel> AllStacks { get { return _allStacks; } }

        public ObservableCollection<StackModel> Stacks { get { return _model.Stacks; } }

        public CardStacksViewModel(CardModel model, ObservableCollection<StackModel> allStacks)
        {
            _model = model;
            _allStacks = allStacks;

            _tempStacks = new ObservableCollection<StackModel>();

            CopyStacks(Stacks, _tempStacks);

            SaveCommand = new Command(execute: () => UpdateCardStacks(_tempStacks));
        }

        private void CopyStacks(ObservableCollection<StackModel> from, ObservableCollection<StackModel> to)
        {
            for(int i = 0; i < from.Count; i++)
            {
                if (!to.Contains(from[i]))
                {
                    to.Add(from[i]);
                }
            }
        }

        public void UpdateTempStacks(bool isChecked, StackModel stack)
        {
            Console.WriteLine("Updating in progress");
            if (!isChecked)
            {
                _tempStacks.Remove(stack);
            }
            else if (isChecked)
            {
                _tempStacks.Add(stack);
            }
            //if (Stacks.Contains(stack))
            //{
            //    if(!isChecked)
            //    {
            //        _tempStacks.Remove(stack);
            //    }
            //}
            //else
            //{
            //    if(isChecked)
            //    {
            //        _tempStacks.Add(stack);
            //    }
            //}
            Console.WriteLine("Updating done");
        }

        private void SubscribeCardAndStack(StackModel stack)
        {
            stack.SubscribeObject(_model);
            _model.SubscribeObject(stack);
        }
        
        private void UnsubscribeCardAndStack(StackModel stack)
        {
            stack.UnsubscribeObject(_model);
            _model.UnsubscribeObject(stack);
        }

        private async void UpdateCardStacks(ObservableCollection<StackModel> stacks)
        {
            Console.WriteLine("Saving initated");
            ////CopyStacks(_tempStacks, Stacks);
            //Console.WriteLine("Card ==================================/n");

            //Console.WriteLine("_tempCount: " + stacks.Count);
            //Console.WriteLine("Stacks.Count: " + Stacks.Count);

            for (int i = 0; i < stacks.Count; i++)
            {
                //Console.WriteLine("i is: " + i);

                SubscribeCardAndStack(stacks[i]);
            }

            //Console.WriteLine("_tempCount: " + stacks.Count);
            //Console.WriteLine("Stacks.Count: " + Stacks.Count);
            //Console.WriteLine("Card ----------------------------------/n");

            //Console.WriteLine("_tempCount: " + stacks.Count);
            //Console.WriteLine("Stacks.Count: " + Stacks.Count);
            int n = 1;
            //Console.WriteLine("n: " + n);

            for (int i = Stacks.Count; i > 0; i--)
            {
                //Console.WriteLine("i is: " + i);
                //Console.WriteLine("n: " + n);

                if (!stacks.Contains(Stacks[i - n]))
                {

                    UnsubscribeCardAndStack(Stacks[i - n]);

                    ////Console.WriteLine("1 - Stacks.Count: " + Stacks.Count);
                    //tempStack.UnsubscribeObject(_model);
                    ////Stacks[i - n].ForgetObservable(_model);

                    ////Console.WriteLine("2 - Stacks.Count: " + Stacks.Count);
                    //_model.UnsubscribeObject(tempStack);
                    ////_model.ForgetObservable(Stacks[i - n]);
                    ////Console.WriteLine("3 - Stacks.Count: " + Stacks.Count);
                }
            }

            //Console.WriteLine("Card ==================================/n");
            //for(int i = 0; i < Stacks.Count; i++)
            //{
            //    Stacks[i].Add(_model);
            //}

            Console.WriteLine("Saving finished");

            await Navigation.PopAsync();
        }
    }
}
