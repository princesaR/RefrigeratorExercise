using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorProject
{
    public class GameFunctions
    { 
        public static void PrintRefrigerator(Refrigerator currentRefrigerator)
        {
            Console.WriteLine(currentRefrigerator);
        }
        public static void PrintLeftPlaceInRefrigerator(Refrigerator currentRefrigerator)
        {
            var place = currentRefrigerator.PlaceLeftinRefrigerator();
            Console.WriteLine("Left place in refrigerator : " + place);
        }
        public static void AddItemFromUser(Refrigerator currentRefrigerator)
        {
            var newItem = InputValidation.InputItem();
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
        public static void PutOutItemWithId(Refrigerator currentRefrigerator)
        {
            var id = InputValidation.EnterItemId();
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
        public static void CleanRefrigerator(Refrigerator currentRefrigerator)
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
        public static void WhatIWantToEat(Refrigerator currentRefrigerator)
        {
            Console.WriteLine("choose kind of item and chosher of item");
            var kind = InputValidation.EnterKind();
            var cosher = InputValidation.EnterCosher();
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
        public static void ItemsOrderByExpiryDate(Refrigerator currentRefrigerator)
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
        public static void ShelvesOedersByLeftPlace(Refrigerator currentRefrigerator)
        {
            var shelvesByLeftPlace = currentRefrigerator.SortedShelvesByLeftPlace();
            Console.WriteLine(" shelves sorted by their left place");
            foreach ( var shelf in shelvesByLeftPlace)
            {
                Console.WriteLine(shelf + "\n");
            }
        }
        public static void RefrigeratorsOrdersByLeftPlace(List<Refrigerator> refrigerators)
        {
           var refrigeratorsByLeftPlace =  Refrigerator.SortedRefrigeratorsByLeftPlace(refrigerators);
            Console.WriteLine(" Refrigerators sorted by their left place");
            foreach ( var refrigerator in refrigeratorsByLeftPlace)
            {
                Console.WriteLine( refrigerator + " ");
            }

        }
        public static void GetReadyForShopping(Refrigerator currentRefrigerator)
        {
            currentRefrigerator.Shopping();
        }
        public static void PrintList( List<Item> items )
        {
            foreach( var item in items ) 
            {
                Console.WriteLine(item + " ");
            }
        }

    }
}
