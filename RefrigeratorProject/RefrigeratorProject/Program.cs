using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorProject
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Console Application in C# for Refrigerators\r");
            Console.WriteLine("------------------------\n");

            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\t1 - Viewing the contents of a refrigerator.");
            Console.WriteLine("\t2 - Left Place in the refrigerator");
            Console.WriteLine("\t3 - Put an item in the refrigerator.");
            Console.WriteLine("\t4 - Remove an item from the refrigerator.");
            Console.WriteLine("\t5 - Clean the refrigerator.");
            Console.WriteLine("\t6 - What do I want to eat?.");
            Console.WriteLine("\t7 - Sorted products by their expiration date..");
            Console.WriteLine("\t8 - Sorted shelves according to the free space left on them.");
            Console.WriteLine("\t9 - Sorted refrigerators according to the free space left in them..");
            Console.WriteLine("\t10 - Prepare the refrigerator for shopping.");
            Console.WriteLine("\t100 - Close the system..");
            Console.Write("Your option? ");

            var selectedAction = Console.ReadLine();

            while (!selectedAction.Equals("100"))
            {

                switch (selectedAction)
                {
                    case "1":

                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        break;
                    case "8":
                        break;
                    case "9":
                        break;
                    case "10":
                        break;
                    default:
                        Console.WriteLine("You did not enter any of the options above.");
                        break;
                }
                selectedAction = Console.ReadLine();
            }


        }
        //var refrigerator1 = new Refrigerator("model1", "white", 3,
        //    new List<Shelf>() {
        //    new Shelf(1, 10.0, new List<Item>()),
        //    new Shelf(2, 10.0, new List<Item>()),
        //    new Shelf(3, 10.0, new List<Item>()),
        //    });


        //var refrigerator2 = new Refrigerator("model1", "black", 3,
        //   new List<Shelf>() {
        //    new Shelf(1, 35.0, new List<Item>()),
        //    new Shelf(2, 35.0, new List<Item>()),
        //    new Shelf(3, 35.0, new List<Item>()),
        //   });

        //var refrigerator3 = new Refrigerator("model1", "red", 3,
        //  new List<Shelf>() {
        //    new Shelf(1, 40.0, new List<Item>()),
        //    new Shelf(2, 40.0, new List<Item>()),
        //    new Shelf(3, 40.0, new List<Item>()),
        //  });

        //refrigerator1.EnterItem(new Item("chips", Kind.Food, Cosher.Milky, DateTime.Now.AddDays(-1), 5.0));
        //refrigerator1.EnterItem(new Item("banana", Kind.Food, Cosher.Milky, DateTime.Now.AddDays(2), 5.0));
        //refrigerator1.EnterItem(new Item("bread", Kind.Food, Cosher.Meat, DateTime.Now.AddDays(3), 5.0));
        //refrigerator1.EnterItem(new Item("chips", Kind.Food, Cosher.Meat, DateTime.Now.AddDays(1), 5.0));
        //refrigerator1.EnterItem(new Item("chips", Kind.Food, Cosher.Milky, DateTime.Now.AddDays(100), 5.0));
        //refrigerator1.EnterItem(new Item("chips", Kind.Food, Cosher.Milky, DateTime.Now.AddDays(100), 5.0));
        ////refrigerator1.Shopping();
        //Console.WriteLine(refrigerator1.PlaceLeftinRefrigerator());
        //Console.WriteLine(refrigerator1);
        // refrigerator1.Shopping();
        ////   refrigerator1.Shopping();

        ////var list = refrigerator1.SortedShelvesByLeftPlace();
        ////foreach( var  item in list )
        ////{
        ////    Console.WriteLine(item);
        ////}
        ////  refrigerator1.Shopping();
        ////  Console.WriteLine(refrigerator1);
        ////Console.WriteLine(" hello wellcome to the console appliction in the Regrigeratores  \n" +
        ////                    " press 1: to print all the.... \n" +
        ////                    " prees 2: to... \n" +
        ////                    " press 3:  to ... \n" +
        ////                    " press 4:  to ... \n" +
        ////                    " press 5:  to ... \n" +
        ////                    " press 6:  to ... \n" +
        ////                    " press 7:  to ... \n" +
        ////                    " press 8:  to ... \n" +
        ////                    " press 9:  to ... \n" +
        ////                    " press 10:  to ... \n" +
        ////                    " press 100:  to close the application" +
        ////                    " ... \n");



    }
    }
}
