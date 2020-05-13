using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HierarchNav
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {

        private double totalPrice = 0;

        private Dictionary<string, double> orderItems = new Dictionary<string, double>();

        public Menu()
        {
            InitializeComponent();

            totalPriceLabel.BindingContext = this;
            totalPriceLabel.SetBinding(Label.TextProperty, "totalPrice", BindingMode.OneWay);

        }

        private void checkBox_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender.Equals(burgerCheckBox))
            {
                if (burgerCheckBox.IsChecked)
                {
                    if (!orderItems.ContainsKey("Burger"))
                    {
                        totalPrice += Convert.ToDouble(burgerPrice.Text);
                        orderItems.Add("Burger", Convert.ToDouble(burgerPrice.Text));
                    }
                }
                else
                {
                    if (orderItems.ContainsKey("Burger"))
                    {
                        orderItems.Remove("Burger");
                        totalPrice -= Convert.ToDouble(burgerPrice.Text);
                    }
                }
            }
            else if (sender.Equals(pizzaCheckBox))
            {
                if (burgerCheckBox.IsChecked)
                {
                    if (!orderItems.ContainsKey("Pizza"))
                    {
                        totalPrice += Convert.ToDouble(pizzaPrice.Text);
                        orderItems.Add("Pizza", Convert.ToDouble(pizzaPrice.Text));
                    }
                }
                else
                {
                    if (orderItems.ContainsKey("Pizza"))
                    {
                        totalPrice -= Convert.ToDouble(pizzaPrice.Text);
                        orderItems.Remove("Pizza");
                    }
                }
            }
            else if (sender.Equals(fishCheckBox))
            {
                if (burgerCheckBox.IsChecked)
                {
                    if (!orderItems.ContainsKey("Fish"))
                    {
                        totalPrice += Convert.ToDouble(fishPrice.Text);
                        orderItems.Add("Fish", Convert.ToDouble(fishPrice.Text));
                    }
                }
                else
                {
                    if (orderItems.ContainsKey("Fish"))
                    {
                        totalPrice -= Convert.ToDouble(fishPrice.Text);
                        orderItems.Remove("Fish");
                    }
                }
            }
            else if (sender.Equals(kebabCheckBox))
            {
                if (burgerCheckBox.IsChecked)
                {
                    if (!orderItems.ContainsKey("Kebab"))
                    {
                        totalPrice += Convert.ToDouble(kebabPrice.Text);
                        orderItems.Add("Kebab", Convert.ToDouble(kebabPrice.Text));
                    }
                }
                else
                {
                    if (orderItems.ContainsKey("Kebab"))
                    {
                        totalPrice -= Convert.ToDouble(kebabPrice.Text);
                        orderItems.Remove("Kebab");
                    }
                }
            }
            else if (sender.Equals(chipsCheckBox))
            {
                if (burgerCheckBox.IsChecked)
                {
                    if (!orderItems.ContainsKey("Chips"))
                    {
                        totalPrice += Convert.ToDouble(chipsPrice.Text);
                        orderItems.Add("Chips", Convert.ToDouble(chipsPrice.Text));
                    }
                }
                else
                {
                    if (orderItems.ContainsKey("Chips"))
                    {
                        totalPrice -= Convert.ToDouble(chipsPrice.Text);
                        orderItems.Remove("Chips");
                    }
                }
            }

            totalPriceLabel.Text = String.Format("{0:0.00}", totalPrice);
        }

        private async void orderButton_Clicked(object sender, EventArgs e)
        {
            var nextPage = new Cart(orderItems, totalPrice);
            await Navigation.PushAsync(nextPage, true);
        }
    }
}