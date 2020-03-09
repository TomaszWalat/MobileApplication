using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MyModel m = new MyModel("Tomasz", 23, null, null);
            m.Display();
        }
    }
}
