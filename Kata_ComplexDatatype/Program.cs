using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OnlineOrderSystem
{
    class Program
    {
        private static List<OnlineOrder> orders;
        static void Main(string[] args)
  {
           MakeOrder();

        }

        public static void MakeOrder()
        {
            List<OnlineOrder> listOfOrders = new List<OnlineOrder>();
            List<String> allItemsList = new List<string>();
            List<string> uniqueList = new List<string>();

            bool b = true;
            while (true)
            {
                int choice = 0;
                Console.WriteLine("1: Order an electric bicycle");
                Console.WriteLine("2: Order a trampoline order");
                Console.WriteLine("3: Order a bouquet");
                Console.WriteLine("4: Order something else");
                Console.WriteLine("5: Show all orders");
                Console.WriteLine("6: Show how many times each item was ordered");
                Console.WriteLine("7: Show time of order and item ordered");
                Console.WriteLine("8: Exit menu");

                Console.Write("Type option and press enter:");
                while (true)
                {
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch
                    {

                        Console.WriteLine("\nInvalid choice. Please retry.");
                        Console.Write("Type option and press enter:");
                    }
                }

                Console.Clear();

                if (choice == 1)
                {
                    listOfOrders.Add(new OnlineOrder("electric bicycle"));
                    allItemsList.Add("electric bicycle");
                    if (!uniqueList.Contains("electric bicycle"))
                    {
                        uniqueList.Add("electric bicycle");
                    }

                }
                else if (choice == 2)
                {
                    listOfOrders.Add(new OnlineOrder("trampoline"));
                    allItemsList.Add("trampoline");
                    if (!uniqueList.Contains("trampoline"))
                    {
                        uniqueList.Add("trampoline");
                    }


                }
                else if (choice == 3)
                {
                    listOfOrders.Add(new OnlineOrder("bouquet"));
                    allItemsList.Add("bouquet");
                    if (!uniqueList.Contains("bouquet"))
                    {
                        uniqueList.Add("bouquet");
                    }

                }
                else if (choice == 4)
                {
                    Console.WriteLine("What would u like to order? ");
                    Console.WriteLine("(0) to return to menu.");
                    var t = Convert.ToString(Console.ReadLine());
                    if (t == "0" || t == null || t == "")
                    {
                        continue;
                    }
                    if (!uniqueList.Contains(t.ToLower()) && t != "")
                    {
                        uniqueList.Add(t.ToLower());
                    }

                    if (t != "" && t != "0")
                    {
                        listOfOrders.Add(new OnlineOrder(t.ToLower()));
                        allItemsList.Add(t.ToLower());
                    }
                    Console.Clear();
                }
                else if (choice == 5)
                {
                    Console.WriteLine("List of ordered items: ");
                    listOfOrders.ForEach(x => Console.WriteLine(x.Name + "\n"));
                    Console.WriteLine("Press any key to return to menu");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (choice == 6)
                {

                    foreach (var VARIABLE in uniqueList)
                    {
                        var count = allItemsList.FindAll(x => x.Contains(VARIABLE)).Count;
                        Console.WriteLine($"{count} orders of {VARIABLE} has been made!");
                        Console.WriteLine();
                    }
                    Console.WriteLine("Press any key to return to menu");
                    Console.ReadKey();
                    Console.Clear();

                }
                else if (choice == 7)
                {
                    Console.Clear();
                    foreach (var VARIABLE in listOfOrders)
                    {
                        Console.WriteLine($"{VARIABLE.Name} was ordered {VARIABLE._TimeOfOrder.ToLongDateString()}" +
                                          $" at {VARIABLE._TimeOfOrder.ToShortTimeString()}\n");
                    }

                    Console.WriteLine("Press any key to return to menu");
                    Console.ReadKey();
                }
                else if (choice == 8)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice, retry.\n");

                }

            }
        }
    }
}
