using System;
using System.Collections.Generic;
using System.Text;

namespace Binding_5
{
    class Model
    {
        private string _welcomeMessage = "Welcome to Xamarin.Forms!";

        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set
            {
                if(value != _welcomeMessage)
                {
                    _welcomeMessage = value;
                }
            }
        }

        public void UserRespond()
        {
            WelcomeMessage = "Hello World!";
        }
    }
}
