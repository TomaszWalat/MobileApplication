using FlashCardsApp.Model;
using FlashCardsApp.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCardsApp
{
    public partial class App : Application
    {
        private MainPageModel _model;

        //public MainPageModel Model { get { return _model; } }

        public App()
        {
            _model = new MainPageModel();

            InitializeComponent();

            MainPage = new NavigationPage(new MainPageTabbed(_model));
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
