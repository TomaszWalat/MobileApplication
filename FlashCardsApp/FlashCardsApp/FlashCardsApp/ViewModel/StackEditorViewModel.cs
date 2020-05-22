using FlashCardsApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlashCardsApp.ViewModel
{
    public class StackEditorViewModel
    {
        private StackModel _original;
        private StackModel _model;

        public StackModel Model { get; set; }

        public ICommand SaveCommand { get; set; }

        protected INavigation Navigation => Application.Current.MainPage.Navigation;

        public StackEditorViewModel(StackModel model, ObservableCollection<StackModel> allStacks = null)
        {
            _original = model;

            Model = new StackModel(_original.Name, _original.Description);

            SaveCommand = new Command(execute: () => 
            {
                Console.WriteLine("1 Saving...................");

                if (Model.Name != "")
                {
                    Console.WriteLine("2 Saving...................");
                    _original.Name = Model.Name;
                    _original.Description = Model.Description;

                    if(allStacks != null && !allStacks.Contains(model))
                    {
                        allStacks.Add(model);

                        Console.WriteLine("3 Saving...................");
                    }
                }

                Navigation.PopAsync();
            });
        }
    }
}
