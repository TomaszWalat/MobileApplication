using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HierarchNav
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cart : ContentPage
    {
        Dictionary<string, double> order;

        public Cart(Dictionary<string, double> orderItems, double priceTotal)
        {
            InitializeComponent();

            priceTotalLabel.Text = String.Format("£ {0:0.00}", priceTotal);

            ShowItem(false, "Burger");
            ShowItem(false, "Pizza");
            ShowItem(false, "Fish");
            ShowItem(false, "Kebab");
            ShowItem(false, "Chips");

            UpdateItems(orderItems);

            order = orderItems;
        }

        private void ShowItem(bool flag, string item)
        {
            IList<View> temp = null;

            switch (item)
            {
                case "Burger":
                    temp = Burger.Children;
                    break;
                case "Pizza":
                    temp = Pizza.Children;
                    break;
                case "Fish":
                    temp = Fish.Children;
                    break;
                case "Kebab":
                    temp = Kebab.Children;
                    break;
                case "Chips":
                    temp = Chips.Children;
                    break;
            }

            if (!temp.Equals(null))
            {
                foreach (View i in temp)
                {
                    i.IsVisible = flag;
                }
            }
        }

        private void UpdateItems(Dictionary<string, double> items)
        {
            foreach(KeyValuePair<string, double> entry in items)
            {
                ShowItem(true, entry.Key);
            }
        }

        private void paymentButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}