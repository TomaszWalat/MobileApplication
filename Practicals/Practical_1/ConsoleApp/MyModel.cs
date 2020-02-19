using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class MyModel
    {
        public string FirstName { get; set; }
        public string KnownAs { get; set; }
        public int Age { get; set; }
        public uint? PhoneNumber { get; set; }

        public MyModel(string FirstName, int Age, string KnownAs=null, uint? PhoneNumber=null)
        {
            this.FirstName = FirstName;
            this.KnownAs = KnownAs;
            this.Age = Age;
            this.PhoneNumber = PhoneNumber;
        }

        public void Display()
        {
            string outputString = $"This is {FirstName}";

            if (KnownAs != null)
            {
                outputString += $", also known as {KnownAs}";
            }

            outputString += $", Age {Age}";

            if(PhoneNumber != null)
            {
                outputString += $", Phone number {PhoneNumber}";
            }

            Console.WriteLine(outputString);

            //Console.WriteLine($"This is {FirstName}, also known as {KnownAs}, Age {Age}, Phone Number {PhoneNumber}");
        }

    }
}
