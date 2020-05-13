using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCardsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Stack : ContentView
    {
        public Stack()
        {
            InitializeComponent();

            Card card1 = new Card();

            testCard = card1;
            //Card_One.AddLogicalChild(card1);

            GridContent.Children.Add(card1);
        }
    }
}