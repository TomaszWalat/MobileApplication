﻿using FlashCardsApp.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCardsApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPageTabbed());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
