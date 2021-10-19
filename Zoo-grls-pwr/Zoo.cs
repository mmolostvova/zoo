using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo_grls_pwr
{
    class Zoo
    {
        public int AmauntVisitors = 0;
        public double ProfitOfDay = 0;
        public double Treat = 200;
        public string ZooName;
        public int MaxVisitors = 5;
        public List<Animal> Animals;
        public Zoo(string zooName)
        {
            ZooName = zooName;

            Animals = new List<Animal>()
            {
                {new Animal("Tiger", 100.00, true)},
                {new Animal("Snake", 300.00, true)},
                {new Animal("Spiders", 350.00, true)},
                {new Animal("Raccon", 200.00, false)},
                {new Animal("Fox", 150.00, false)},
                {new Animal("Hippo", 400.00, false)},
                {new Animal("Penguins", 400.00, false)},
                {new Animal("Bears", 200.00, false)},
                {new Animal("Giraffe", 300.00, false)},
                {new Animal("Monkey", 200.00, false)},
            };
        }
    }
}
