using System;
using System.Collections.Generic;
using System.Text;

namespace BodyMassIndex
{
    class BodyParameter
    {
        private double? _value;
        private double _max;
        private double _min;
        private string _nameString;
        private string _unitString;

        public BodyParameter(double min, double max, string parameterName, string units)
        {
            _max = max;
            _min = min;
            _nameString = parameterName;
            _unitString = units;
        }

        public double? Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value >= _min && value <= _max)
                {
                    _value = value;
                }
                else
                {
                    _value = null;
                }
            }
        }

        public static implicit operator double?(BodyParameter d)
        {
            return d.Value;
        }

        public bool SetValueFromString(string stringValue, out string errorString)
        {
            bool valueSetCorrectly = false;

            if(double.TryParse(stringValue, out double newValue))
            {
                Value = newValue;

                if(Value == null)
                {
                    errorString = string.Format(_nameString + " must be between {0:f1} and {1:f1} ", _min, _max) + _unitString;
                }
                else
                {
                    errorString = "";
                    valueSetCorrectly = true;
                }
            }
            else 
            {
                Value = null;
                errorString = "Please enter a numerical value";
            }

            return valueSetCorrectly;
        }
    }
}
