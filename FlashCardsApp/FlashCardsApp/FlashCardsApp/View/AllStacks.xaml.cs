﻿using FlashCardsApp.Model;
using FlashCardsApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCardsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllStacks : ContentPage
    {
        private AllStacksViewModel _viewModel;

        public AllStacks(ObservableCollection<StackModel> allStacks, ObservableCollection<CardModel> allCards)
        {
            InitializeComponent();

            _viewModel = new AllStacksViewModel(this, allStacks, allCards);
            BindingContext = _viewModel;

            AllStacksListView.SelectionMode = ListViewSelectionMode.Single;
            AllStacksListView.ItemTapped += AllStacksListView_ItemTapped;
        }

        private void AllStacksListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //AllStacksListView.SelectedItem = null;
            //Console.WriteLine(e.Item.GetType().Name.ToString());
            _viewModel.GoToStackDetails(e.ItemIndex);
        }
    }
}