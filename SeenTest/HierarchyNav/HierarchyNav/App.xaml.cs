using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HierarchyNav
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DetailsPage startPage = new DetailsPage();

            MainPage = new NavigationPage(startPage);
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
