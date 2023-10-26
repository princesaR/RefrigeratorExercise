using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace RefrigeratorProject
{
    public class Game
    {
        public Refrigerator currentRfrigerator;
        public List<Refrigerator> refrigerators;
        public Dictionary<int, System.Action<Refrigerator>> currentRefrigeratorActions;
      
        public Game()
        {
            this.refrigerators = CreateRefrigerators();
            this.currentRfrigerator = ChooseCurrent();
            this.currentRefrigeratorActions = GetRefrigeratorFunctions();
           
        }

        private Dictionary<int, System.Action<Refrigerator>> GetRefrigeratorFunctions()
        {
            var functions = new Dictionary<int, System.Action<Refrigerator>>();
            functions[1] = GameFunctions.PrintRefrigerator;
            functions[2] = GameFunctions.PrintLeftPlaceInRefrigerator;
            functions[3] = GameFunctions.AddItemFromUser;
            functions[4] = GameFunctions.PutOutItemWithId;
            functions[5] = GameFunctions.CleanRefrigerator;
            functions[6] = GameFunctions.WhatIWantToEat;
            functions[7] = GameFunctions.ItemsOrderByExpiryDate;
            functions[8] = GameFunctions.ShelvesOedersByLeftPlace;
            functions[10] = GameFunctions.GetReadyForShopping;

            return functions;
        }
        
        private List<Refrigerator> CreateRefrigerators()
        {
            var refrigerators = new List<Refrigerator>();

            var refrigerator1 = new Refrigerator("model1", "white", 3,
            new List<Shelf>() {
            new Shelf(1, 20.0, new List<Item>()),
            new Shelf(2, 10.0, new List<Item>()),
            new Shelf(3, 10.0, new List<Item>()),
            });

            var refrigerator2 = new Refrigerator("model1", "black", 3,
               new List<Shelf>() {
                new Shelf(1, 20.0, new List<Item>()),
                new Shelf(2, 60.0, new List<Item>()),
                new Shelf(3, 60.0, new List<Item>()),
               });

            var refrigerator3 = new Refrigerator("model1", "red", 3,
              new List<Shelf>() {
                new Shelf(1, 40.0, new List<Item>()),
                new Shelf(2, 40.0, new List<Item>()),
                new Shelf(3, 40.0, new List<Item>()),
              });

            refrigerator1.EnterItem(new Item("chips", Kind.Food, Cosher.Milky, DateTime.Now.AddDays(-1), 5.0));
            refrigerator1.EnterItem(new Item("banana", Kind.Food, Cosher.Milky, DateTime.Now.AddDays(2), 5.0));
            refrigerator1.EnterItem(new Item("bread", Kind.Food, Cosher.Meat, DateTime.Now.AddDays(3), 5.0));
            refrigerator1.EnterItem(new Item("chips", Kind.Food, Cosher.Meat, DateTime.Now.AddDays(1), 5.0));
            refrigerator1.EnterItem(new Item("chips", Kind.Food, Cosher.Milky, DateTime.Now.AddDays(100), 5.0));
            refrigerator1.EnterItem(new Item("chips", Kind.Food, Cosher.Milky, DateTime.Now.AddDays(100), 5.0));
            refrigerators.Add(refrigerator1);
            refrigerators.Add(refrigerator2);
            refrigerators.Add(refrigerator3);

            return refrigerators;
        }
        private Refrigerator ChooseCurrent()
        {
            var random = new Random();
            var currentRefrigerator = this.refrigerators.ElementAt(random.Next(refrigerators.Count));

            return currentRefrigerator;
        }
        public void StartGame()
        {
            Console.WriteLine("Console Application in C# for Refrigerators\r");
            Console.WriteLine("------------------------\n");
            Console.WriteLine("Note! your game is with random refrigerator from list of " + refrigerators.Count + " refrigerators. \n");
            PrintInstrucitons();
            ActionByUserChoice();
        }
        private  void PrintInstrucitons()
        {
            Console.WriteLine("Choose an option from the following list:\n");
            Console.WriteLine("\t1 - Viewing the contents of a refrigerator.\n");
            Console.WriteLine("\t2 - Left Place in the refrigerator\n");
            Console.WriteLine("\t3 - Put an item in the refrigerator.\n");
            Console.WriteLine("\t4 - Remove an item from the refrigerator.\n");
            Console.WriteLine("\t5 - Clean the refrigerator.\n");
            Console.WriteLine("\t6 - What do I want to eat?.\n");
            Console.WriteLine("\t7 - Sorted products by their expiration date.\n");
            Console.WriteLine("\t8 - Sorted shelves according to the free space left on them.\n");
            Console.WriteLine("\t9 - Sorted refrigerators according to the free space left in them.\n");
            Console.WriteLine("\t10 - Prepare the refrigerator for shopping.\n");
            Console.WriteLine("\t100 - Close the system..\n");
            Console.Write("Your option? \n enter your choice here: ");

        }
        private  void ActionByUserChoice()
        {
            var selectedAction = Console.ReadLine();
            var num = 0;
            while (!selectedAction.Equals("100"))
            {
                if (int.TryParse(selectedAction, out num) && num > 0 && num < 11)
                {
                    if (num == 9)
                    {
                        GameFunctions.RefrigeratorsOrdersByLeftPlace(refrigerators);
                    }
                    else
                    {
                        currentRefrigeratorActions[num](currentRfrigerator);
                    }
                }
                else
                {
                    Console.WriteLine("You did not enter any of the options above.");
                }
                Console.WriteLine("===================================================");
                Console.Write("Your option? \nenter yout choice here: ");
                selectedAction = Console.ReadLine();
            }  
         }
       

    }

}
