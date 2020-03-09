using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;

namespace Binding_2
{
    class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //private List<string> sayings = new List<string>
        //{
        //    "May the Force be With You",
        //    "Live long and prosper",
        //    "Nanoo nanoo"
        //};

        private int count = 0;
        private string _numberAsString = "0";
        public string NumberAsString
        {
            get 
            {
                Debug.WriteLine("getting NumberAsString");
                Debug.WriteLine("   it is: " + _numberAsString);
                Debug.WriteLine("   count is: " + count);
                count += 1;
                string str = $"{count}";
                Debug.WriteLine("+1 to count");
                Debug.WriteLine("   count is: " + count);
                //NumberAsString = str;
                _numberAsString = str;
                Debug.WriteLine("   numAsS is: " + _numberAsString);
                //if (PropertyChanged != null)
                //{
                    //PropertyChanged(this, new PropertyChangedEventArgs("NumberAsString"));
                //}
                return _numberAsString;
            }
            //set
            //{
            //    if (value != _numberAsString)
            //    {
            //        _numberAsString = value;

            //        if (PropertyChanged != null)
            //        {
            //            PropertyChanged(this, new PropertyChangedEventArgs("NumberAsString"));
            //        }
            //    }
            //}
        }

        public void IncrementCounter()
        {
            Debug.WriteLine("Incerementing counter");
            //Debug.WriteLine("number as string is: " + NumberAsString);
            PropertyChanged(this, new PropertyChangedEventArgs("NumberAsString"));
            //_ = NumberAsString;
        }

        //private int next = 0;

        //string _currentSaying = "Welcome to Xamarin Forms!";
        //public string CurrentSaying
        //{
        //    get => _currentSaying;
        //    set
        //    {
        //        if(!value.Equals(_currentSaying))
        //        {
        //            _currentSaying = value;

        //            if(PropertyChanged != null)
        //            {
        //                PropertyChanged(this, new PropertyChangedEventArgs("CurrentSaying"));
        //            }
        //        }
        //    }
        //}

        //public void NextMessage()
        //{
        //    CurrentSaying = sayings[next];
        //    next = (next + 1) % sayings.Count;
        //}

        //bool _visible = true;

        //public bool IsTrue
        //{
        //    get => _visible;
        //    set
        //    {
        //        if(value != _visible)
        //        {
        //            _visible = value;

        //            if(PropertyChanged != null)
        //            {
        //                PropertyChanged(this, new PropertyChangedEventArgs("IsTrue"));
        //            }
        //        }
        //    }
        //}

        public Model()
        {

        }
    }
}
