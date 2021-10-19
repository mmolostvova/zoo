using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo_grls_pwr
{
    class Visitors
    {
        public int Age;
        public double Money;

        public Visitors(int age)
        {
            Age = age;
            Random rnd = new Random();
            Money = rnd.Next(1, 5000);
        }
    }
}
