using FlashCardsApp.Misc;
using FlashCardsApp.Model;
using FlashCardsApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FlashCardsApp.Misc
{
    class ItemTemplateSelector : DataTemplateSelector
    {
        private DataTemplate _itemSelected = null;
        private string _itemType = "";

        private CardModel _card;
        private StackCardsViewModel _stackCardsViewModel;
        private StackModel _stack;
        private CardStacksViewModel _cardStacksViewModel;

        public ContentPage PageRef { get; set; }

        public DataTemplate ItemSelected
        {
            get
            {
                if (_itemSelected == null)
                {
                    _itemSelected = new DataTemplate(() =>
                    {
                        MenuItem item1 = new MenuItem
                        {
                            Text = "Delete",
                            IsDestructive = true
                        };

                        item1.SetBinding(MenuItem.CommandProperty, new Binding("DeleteCommand", source: PageRef.BindingContext));
                        item1.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));

                        MenuItem item2 = new MenuItem
                        {
                            Text = "Edit",
                            IsDestructive = true
                        };

                        item2.SetBinding(MenuItem.CommandProperty, new Binding("EditCommand", source: PageRef.BindingContext));
                        item2.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));

                        ViewCell cell = null;

                        if (_itemType.Equals("CardModel"))
                        {
                            cell = new CardViewCell();

                            cell.ContextActions.Add(item1);
                            cell.ContextActions.Add(item2);
                        }
                        else if (_itemType.Equals("StackModel"))
                        {
                            cell = new StackViewCell();

                            cell.ContextActions.Add(item1);
                            cell.ContextActions.Add(item2);
                        }
                        else if (_itemType.Equals("CheckBoxCard"))
                        {
                            bool isInStack = _stackCardsViewModel.Cards.Contains(_card);
                            cell = new CheckBoxCardViewCell(isInStack, _stackCardsViewModel);
                        }
                        else if(_itemType.Equals("CheckBoxStack"))
                        {
                            bool hasCard = _cardStacksViewModel.Stacks.Contains(_stack);
                            cell = new CheckBoxStackViewCell(hasCard, _cardStacksViewModel);
                        }
                        //else if(_itemType.Equals("Flashcard"))
                        //{
                        //    cell = new FlashcardViewCell();
                        //}

                        return cell;
                    });
                }
                //itemType = "";

                return _itemSelected;
            }
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            //Console.WriteLine("OnSelectedTemplate has been fired; item is: " + item.GetType().Name.ToString() + " ========================================");

            //Console.WriteLine("item: " + item.GetType().Name.ToString() + " container is: " + container.BindingContext.GetType().Name);

            if (item.GetType().Name.ToString() == "CardModel")
            {
                if(container.BindingContext.GetType().Name.ToString() == "StackCardsViewModel")
                {
                    _itemType = "CheckBoxCard";
                    _card = (CardModel)item;
                    _stackCardsViewModel = (StackCardsViewModel)container.BindingContext;
                }
                //else if(container.BindingContext.GetType().Name.ToString() == "PlayFlashcardsViewModel")
                //{
                //    _itemType = "Flashcard";
                //}
                else //if (container.BindingContext.GetType().Name.ToString() == "StackDetailsViewModel")
                {
                    _itemType = "CardModel";
                }
            }
            else if(item.GetType().Name.Equals("StackModel"))
            {
                if(container.BindingContext.GetType().Name.ToString() == "CardStacksViewModel")
                {
                    _itemType = "CheckBoxStack";
                    _stack = (StackModel)item;
                    _cardStacksViewModel = (CardStacksViewModel)container.BindingContext;
                }
                else
                {
                    _itemType = "StackModel";
                }
            }

            return ItemSelected;
        }
    }
}
