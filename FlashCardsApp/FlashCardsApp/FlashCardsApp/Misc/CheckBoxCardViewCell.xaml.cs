using FlashCardsApp.Model;
using FlashCardsApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCardsApp.Misc
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckBoxCardViewCell : ViewCell
    {
        private StackCardsViewModel _viewModel;

        public CheckBoxCardViewCell(bool isTicked, StackCardsViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;

            CellCheckBox.IsChecked = isTicked;
            CellCheckBox.CheckedChanged += CellCheckBox_CheckedChanged;
        }

        private void CellCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            //CardModel card = (CardModel)sender;

            //Console.WriteLine("e.value = " + e.Value);
            //Console.WriteLine("Binding context is " + BindingContext.ToString());

            Console.WriteLine("Starting to update the checkbox list");
            _viewModel.UpdateTempCards(e.Value, (CardModel)BindingContext);
        }
    }
}