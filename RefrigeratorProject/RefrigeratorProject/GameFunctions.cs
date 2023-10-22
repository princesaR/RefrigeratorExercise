using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorProject
{
    public  class GameFunctions
    {
        public Refrigerator currentRefrigerator { get; set; }
        public List<Refrigerator> refrigerators { get; set; }


        public GameFunctions(Refrigerator refrigerator, List<Refrigerator> refrigerators)
        {
            this.currentRefrigerator = refrigerator;
            this.refrigerators = refrigerators;
        }
        private Item InputItem()
        {
            var name = EnterName();
            var kind = EnterKind();
            var cosher = EnterCosher();
            var date = EnterDate();
            var place = EnterPlace();

            var Item = new Item(name, kind, cosher, date, place);

            return Item;

        }
        private string EnterName()
        {
            Console.Write("enetr the name of the item\n enter your choice: ");
            var name = Console.ReadLine();
            return name;
        }
        private Kind EnterKind()
        {
            var input = 0;
            do
            {
                Console.WriteLine("enter the kind of the item. 1 for food 2 for drink");
                Console.Write("enter your choice: ");
                input = IsInputNum();
            } while (input != 1 && input != 2);

            var kind = (Kind)input;
            return kind;
        }
        private Cosher EnterCosher()
        {
            var input = 0;
            do
            {
                Console.WriteLine("enter the Cosher of the Item 1 for milky 2 for meaty 3 for pareve");
                Console.Write("enter your choice: ");
                input = IsInputNum();

            } while (input != 1 && input != 2 && input != 3);

            var cosher = (Cosher)input;
            return cosher;
        }
        private DateTime EnterDate()
        {
            Console.WriteLine("enter the Expiry Date of the item in format [mm/dd/yy] ");
            Console.Write("enter your choice: ");
            var date = IsInputDate();
            
            return date;

        }
        private double EnterPlace()
        {
            Console.WriteLine("enter the place taken by the item");
            Console.Write("enter your choice: ");
            var place = IsInputDouble();
            return place;
        }
        private string EnterItemId()
        {
            Console.WriteLine("enter ID of the Item");
            Console.Write("enter your choice: ");
            var itemId = IsInputNum().ToString();
            return itemId;
        }

        private int IsInputNum()
        {
            var valid = false;
            var input = "";
            int number = 0; ;
            while (!valid)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out number) && number > 0)
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Initial value must be of the type int");
                    Console.WriteLine("\nPlease enter the number again: ");
                }

            }
            return number;
        }
        private double IsInputDouble()
        {
            var valid = false;
            var input = "";
            var doubleNum = 0.0;
            
            while (!valid)
            {
                input = Console.ReadLine();
                if (double.TryParse(input, out doubleNum) && doubleNum > 0)
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Initial value must be of the type double");
                    Console.WriteLine("\nPlease enter the number again: ");
                }
            }
            return doubleNum;

        }
        private DateTime IsInputDate()
        {
            var valid = false;
            var input = "";
            var date = new DateTime();
            while (!valid)
            {
                input = Console.ReadLine();
                if (DateTime.TryParse(input, out date)&& date > DateTime.Now.AddDays(-1))

                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("the input is not a vaild date.");
                    Console.WriteLine("\nPlease enter the date again: ");
                }
            }
            return date;
        }


        public void PrintRefrigerator()
        {
            Console.WriteLine( currentRefrigerator);
        }

        public void PrintLeftPlaceInRefrigerator()
        {
            var place = currentRefrigerator.PlaceLeftinRefrigerator();
            Console.WriteLine("Left place in refrigerator : " + place);
        }
       
        public void AddItemFromUser()
        {
            var newItem = InputItem();
            var isEntered = currentRefrigerator.EnterItem(newItem);
            if (isEntered)
            {
                Console.WriteLine(" the item added successfuly");
            }
            else
            {
                Console.WriteLine("there is no place for the item in this refrigerator.");
            }
        }
        
        public void PutOutItemWithId()
        {
            var id = EnterItemId();
            var takenItem = currentRefrigerator.TakeOutItem(id);
            if(takenItem == null)
            {
                Console.WriteLine("There is no item with this ID");
            }
            else
            {
                Console.WriteLine("The item who taken out is: " + takenItem);
            }
        }
        
        public void CleanRefrigerator()
        {
           var removedItems =  currentRefrigerator.RemoveExpiredItems();
            if( removedItems.Count > 0 )
            {
                Console.WriteLine(" the removed items are: ");
                PrintList(removedItems);
            }
            else
            {
                Console.WriteLine(" there is no items to remove.");
            }
           
        }
        
        public void WhatIWantToEat()
        {
            Console.WriteLine("choose kind of item and chosher of item");
            var kind = EnterKind();
            var cosher = EnterCosher();
            var wantedItems = currentRefrigerator.WantToEat(cosher, kind);
            if( wantedItems.Count > 0)
            {
                Console.WriteLine(" the items with the cosher: " + kind + " and kind: " + cosher); ;
                PrintList(wantedItems);
            }
            else
            {
                Console.WriteLine( " there is no item with this spesific order.");
            }
        }

        public void ItemsOrderByExpiryDate()
        {
            var itemsByExpiryDate = currentRefrigerator.SortAllItemsByExpiraynDate();
            if ( itemsByExpiryDate.Count > 0)
            {
                Console.WriteLine(" items sorted by their expiry date: ");
                PrintList(itemsByExpiryDate);
            }
            else
            {
                Console.WriteLine("there is no items");
            }
            
        }

        public void ShelvesOedersByLeftPlace()
        {
            var shelvesByLeftPlace = currentRefrigerator.SortedShelvesByLeftPlace();
            Console.WriteLine(" shelves sorted by their left place");
            foreach ( var shelf in shelvesByLeftPlace)
            {
                Console.WriteLine(shelf + "\n");
            }
        }

        public void RefrigeratorsOrdersByLeftPlace()
        {
           var refrigeratorsByLeftPlace =  Refrigerator.SortedRefrigeratorsByLeftPlace(refrigerators);
            Console.WriteLine(" Refrigerators sorted by their left place");
            foreach ( var refrigerator in refrigeratorsByLeftPlace)
            {
                Console.WriteLine( refrigerator + " ");
            }

        }

        public void GetReadyForShopping()
        {
            currentRefrigerator.Shopping();
        }

        public void PrintList( List<Item> items )
        {
            foreach( var item in items ) 
            {
                Console.WriteLine(item + " ");
            }
        }

    }
}
