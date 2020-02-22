using System;
using System.Collections.Generic;
using System.Text;

namespace GridLayout
{
    class BmiModel
    {
        private BodyParameter weight = new BodyParameter(min: 20.0, max: 200.0, "Weight", "kg");
        private BodyParameter height = new BodyParameter(min: 0.5, max: 3.0, "Height", "m");

        public double? BmiValue
        {
            get
            {
                if(weight != null && height != null)
                {
                    return weight / (height * height);
                }
                else
                {
                    return null;
                }
            }
        }

        public static implicit operator double?(BmiModel m)
        {
            return m.BmiValue;
        }

        public bool SetWeightAsString(string stringWeight, out string errorString)
        {
            return weight.SetValueFromString(stringWeight, out errorString);
        }

        public bool SetHeighttAsString(string stringHeight, out string errorString)
        {
            return height.SetValueFromString(stringHeight, out errorString);
        }
    }
}
