using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HierarchNav
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Menu menuPage = new Menu();

            MainPage = new NavigationPage(menuPage);
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
