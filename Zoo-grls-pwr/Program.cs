using System;

namespace Zoo_grls_pwr
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo myZoo = new Zoo("Cassablanca");
            Menu.Start(myZoo);
        }
    }
}
