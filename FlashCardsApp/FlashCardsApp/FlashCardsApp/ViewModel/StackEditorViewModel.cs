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
    public class StackEditorViewModel : ViewModelBase
    {
        private StackModel _original;

        public StackModel Model { get; set; }

        public StackEditorViewModel(StackModel model, ObservableCollection<StackModel> allStacks = null)
        {
            _original = model;

            Model = new StackModel(_original.Name, allStacks, _original.Description);

            SaveCommand = new Command(execute: () => 
            {
                if (Model.Name != "")
                {
                    _original.Name = Model.Name;
                    _original.Description = Model.Description;

                    if(allStacks != null && !allStacks.Contains(model))
                    {
                        allStacks.Add(model);
                    }
                }

                Navigation.PopAsync();
            });
        }
    }
}
