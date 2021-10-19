using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo_grls_pwr
{
    static class Menu
    {
        static public void Start(Zoo myZoo)
        {
            while (true)
            {
                PrintMenu(myZoo.ZooName, myZoo.AmauntVisitors);
                ChooseMenuPoin(myZoo);
            }
        }

        static public void PrintMenu(string zooName, int visitorAmount)
        {
            Console.Clear();
            Console.WriteLine($"Welcome to Zoo - {zooName}!!! Visitors in Zoo - {visitorAmount}");
            Console.WriteLine();
            Console.WriteLine("Please selected an option(what do you want to do)\n"
            + "1 - sell the ticket\n"
            + "2 - kick off visitors\n"
            + "3 - close Zoo\n"
            + "4 - Exit");
        }

        static public void ChooseMenuPoin(Zoo myZoo)
        {
            int menuPoint;
            bool isNum = int.TryParse(Console.ReadLine(), out menuPoint);
            while (!isNum || (menuPoint < 1 || menuPoint > 4))
            {
                Console.WriteLine("Wrong input! Try again: ");
                isNum = int.TryParse(Console.ReadLine(), out menuPoint);
            }
            switch (menuPoint)
            {
                case 1:
                    Console.WriteLine("SellTicket");
                    SellTicket(myZoo);
                    break;
                case 2:
                    Console.WriteLine("Kick out");
                    KickOutVisitor(myZoo);
                    break;
                case 3:
                    CloseZoo(myZoo);
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
        static public void CloseZoo(Zoo zoo)
        {
            Console.WriteLine("Close Zoo");
            zoo.AmauntVisitors = 0;
            Console.WriteLine("Zoo closed!!!");
            Console.WriteLine("Profit of day - " + zoo.ProfitOfDay + " $");
            zoo.ProfitOfDay = 0;
            Console.ReadLine();
        }
        static public void KickOutVisitor(Zoo zoo)
        {
            if (zoo.AmauntVisitors > 0)
            {
                zoo.AmauntVisitors--;
            }
        }
        static public void ShowAnimals(List<Animal> Animals)
        {
            int number = 1;
            foreach (var animal in Animals)
            {
                Console.WriteLine(number + " " + animal.NameOfAnimal + " " + animal.Cost + " $");
                number++;
            }

        }
        static public void SellTicket(Zoo zoo)
        {
            List<Animal> availableAnimals = new List<Animal>();
            Visitor newVisitor = new Visitor(AskAge());

            foreach (var animal in zoo.Animals)
            {

                if (animal.IsScary == false && newVisitor.Age <= 10)
                {
                    availableAnimals.Add(animal);
                }
                else if (newVisitor.Age > 10)
                {
                    availableAnimals.Add(animal);
                }

            }
            ShowAnimals(availableAnimals);
            List<int> choosenAnimals = AskNumOfAnimals(availableAnimals.Count);
            double treat = AskTreat() ? zoo.Treat : 0;
            double ticketPrice = CountSum(availableAnimals, choosenAnimals, treat);
            Console.WriteLine($"Total ticket price {ticketPrice} $");

            if (!IsMoneyEnough(newVisitor.Money, ticketPrice))
            {
                Console.WriteLine($"Sorry, you have only {newVisitor.Money} $ - its not enough!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Welcome Have fun in {zoo.ZooName}");
                zoo.AmauntVisitors++;
                zoo.ProfitOfDay += ticketPrice;
                Console.ReadKey();
            }

        }
        private static bool IsMoneyEnough(double visitorMoney, double ticketPrice)
        {
            return visitorMoney >= ticketPrice;
        }

        static public int AskAge()
        {
            int age;
            Console.WriteLine("Enter your age: ");
            bool isNum = int.TryParse(Console.ReadLine(), out age);
            while (!isNum || (age < 1 || age > 100))
            {
                Console.WriteLine("Wrong input! Try again: ");
                isNum = int.TryParse(Console.ReadLine(), out age);
            }
            return age;
        }
        static public List<int> AskNumOfAnimals(int countAvilableAnimals)
        {
            bool isValidInput = false;
            List<int> numbersOfAnimals = new List<int>();
            Console.WriteLine("Please choose number of animals: ");
            do
            {
                numbersOfAnimals.Clear();
                isValidInput = true;
                string stringInput = Console.ReadLine();
                string[] arrOfStringInputs = stringInput.Trim().Split(new char[] { ' ' });

                if (stringInput.Length == 0)
                {
                    isValidInput = false;
                    Console.WriteLine("Your input is empty!");
                    break;
                }
                for (int i = 0; i < arrOfStringInputs.Length; i++)
                {
                    if (!int.TryParse(arrOfStringInputs[i], out int num) && (num <= 0 || num > countAvilableAnimals))
                    {
                        isValidInput = false;
                        break;
                    }
                    numbersOfAnimals.Add(num - 1);
                }
                if (!isValidInput)
                {
                    Console.WriteLine("Your input is invalid! Try again: ");
                }
            }
            while (!isValidInput);
            return numbersOfAnimals;
        }
        static bool AskTreat()
        {
            Console.WriteLine("Would you like to buy treats for animals?");
            Console.WriteLine("Enter 'y' for YES. Other keys for NO ");
            string input = Console.ReadLine();
            if (input == "y")
            {
                return true;
            }
            return false;
        }
        static double CountSum(List<Animal> animals, List<int> choosenAnimals, double treat)
        {
            double sum = 0;
            foreach (int index in choosenAnimals)
            {
                sum = sum + animals[index].Cost;
            }
            sum += treat;
            return sum;
        }

    }
}
