using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Binding_4
{
    class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double _sliderValue = 0;

        public double SliderValue
        {
            get => _sliderValue;
            set
            {
                if (value != _sliderValue)
                {
                    _sliderValue = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("SliderValue"));
                    }
                }
            }
        }

        


    }
}
