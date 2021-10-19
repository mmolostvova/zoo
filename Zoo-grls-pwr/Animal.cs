using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo_grls_pwr
{
    class Animal
    {
        public string NameOfAnimal;
        public double Cost;
        public bool IsScary;

        public Animal(string nameOfAnimal, double cost, bool isScary)
        {
            NameOfAnimal = nameOfAnimal;
            Cost = cost;
            IsScary = isScary;
        }
    }
}