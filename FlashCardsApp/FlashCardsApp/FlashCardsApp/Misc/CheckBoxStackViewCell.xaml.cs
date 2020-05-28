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
    public partial class CheckBoxStackViewCell : ViewCell
    {
        private CardStacksViewModel _viewModel;

        public CheckBoxStackViewCell(bool isTicked, CardStacksViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;

            CellCheckBox.IsChecked = isTicked;
            CellCheckBox.CheckedChanged += CellCheckBox_CheckedChanged;
        }

        private void CellCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            Console.WriteLine("Starting to update the checkbox list");
            _viewModel.UpdateTempStacks(e.Value, (StackModel)BindingContext);
        }
    }
}