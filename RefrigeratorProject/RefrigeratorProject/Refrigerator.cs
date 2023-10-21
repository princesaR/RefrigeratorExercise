using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RefrigeratorProject
{
    public class Refrigerator
    {
        private static int _Id = 1;
        private int _idRefrigerator;
        private string _model;
        private string _color;
        private int _numOfShelf;
        private List<Shelf> _shelves;

        public int IdRefrigerator
        {
            get { return _idRefrigerator; }
            private set
            {
                _idRefrigerator = value;
            }
        }
        public string Model
        {
            get { return _model; }
            set
            {
                
                _model = value;
            }
        }
        public string Color
        {
            get { return _color; }
            set
            {
                _color = value;
            }
        }
        public int NumOfShelf
        {
            get { return _numOfShelf; }
            set
            {
                _numOfShelf = value;
            }
        }
        public List<Shelf> Shelves
        {
            get { return _shelves; }
            set
            {
                _shelves = value;
            }
        }

        public Refrigerator(string model, string color, int numOfShelf, List<Shelf> shelves)
        {
            IdRefrigerator = _Id++;
            Model = model;
            Color = color;
            Model = model;
            NumOfShelf = numOfShelf;
            Shelves = shelves;

        }

        public override string ToString()
        {
            var result = "\n";
            result += "Refrigerator: " + _idRefrigerator + ", model: " + _model.ToString() +", Color: "+_color +", number of shelves: " + _numOfShelf.ToString();
            if (NumOfShelf != 0)
            { 
                result += " the selves: \n";
                foreach (var shelf in Shelves)
                {
                    result += shelf.ToString() + "\n";
                }
            }
            
            return result;

        }

        public double PlaceLeftinRefrigerator()
        {
            var leftPlace = 0.0;
            foreach (var shelf in Shelves)
            {
                leftPlace += shelf.PlaceLeftinShelf();
            }
            return leftPlace;
        }

        public bool EnterItem(Item item)
        {
            foreach (var shelf in _shelves)
            {
                if (shelf.EnterItem(item))
                {
                    return true;

                }
            }
            return false;

        }

        

        public Item? TakeOutItem(string idItem)
        {
            var indexItem = 0;
            foreach (var shelf in _shelves)
            {
                indexItem = shelf.IndexOfItem(idItem);
                if (indexItem != -1)
                {
                    return shelf.TakeOutItem(indexItem);
                }
            }
            return null;
        }

        public List<Item> RemoveExpiredItems()
        {
            var removedItems = new List<Item>();
            foreach (var shelf in _shelves)
            {
               var removedFromShelf = shelf.RemoveExpiredItems();
                removedItems.AddRange(removedFromShelf);
            }
            return removedItems;
        }

        public List<Item> WantToEat(Cosher cashrot, Kind kind)
        {
            var wantedItem = new List<Item>();
            foreach (var shelf in _shelves)
            {
                wantedItem.AddRange(shelf.ItemsWithSpesific(cashrot, kind));
            }
            return wantedItem;
        }

        public List<Item> SortAllItemsByExpiraynDate()
        {
            var items = new List<Item>();
            foreach (var shelf in _shelves)
            {
                items.AddRange(shelf.Items);
            }
            items = items.OrderBy(item => item.ExpiryDate).ToList();
            return items;
        }

        public List<Shelf> SortedShelvesByLeftPlace()
        {
            var sortedShelves = new List<Shelf>();
            sortedShelves = _shelves.OrderByDescending(shelf => shelf.PlaceLeftinShelf()).ToList();
            return sortedShelves;
        }

        public static List<Refrigerator> SortedRefrigeratorsByLeftPlace(List<Refrigerator> refrigerators)
        {
            var sortedByLeftPlace = new List<Refrigerator>();
            sortedByLeftPlace = refrigerators.OrderByDescending(r => r.PlaceLeftinRefrigerator()).ToList();
            return sortedByLeftPlace;

        }



        public void Shopping()
        {
            var leftPlace = PlaceLeftinRefrigerator();
            if (leftPlace < 29)
            {
                
                PrepereForShopping(leftPlace);
            }
            else
            {
                Console.WriteLine(" go shopping there is Enough space : " + leftPlace);
            }
        }

        public void PrepereForShopping(double leftPlace)
        {

            var removedItems = this.RemoveExpiredItems();
            leftPlace += SumOfPlaceByItems(removedItems);
            
            if (leftPlace < 20)
            {
                CountMilky(leftPlace);
            }
            else
            {
                Console.WriteLine("after we remove the expairy items go shopping!");
               //הדפסת המוצרים הלא טובים
            }

        }
        public void CountMilky(double leftPlace)
        {
            leftPlace = CountByDateAndCosher(leftPlace, 3, Cosher.Milky);
            
            if (leftPlace >= 20)
            {
                RemoveByDateAndCosher(3, Cosher.Milky);
                Console.WriteLine("remove milky items, note the removed item were not expiry items.\n go shopping! left place: " + leftPlace);
            }
            else
            {
                CountMeat(leftPlace);
            }
        }

        public void CountMeat(double leftPlace)
        {
            leftPlace = CountByDateAndCosher(leftPlace, 7, Cosher.Meat);
            
            if (leftPlace >= 20)
            {
                RemoveByDateAndCosher(7, Cosher.Meat);
                RemoveByDateAndCosher(3, Cosher.Milky);
                Console.WriteLine("remove milky & meat items, note the removed item were not expiry items.\n go shopping! left place: " + leftPlace);
            }
            else
            {
                CountPareve(leftPlace);
            }
        }

        public void CountPareve(double leftPlace)
        {
            leftPlace = CountByDateAndCosher(leftPlace, 1, Cosher.Pareve);
            if (leftPlace >= 20)
            {
                RemoveByDateAndCosher(7, Cosher.Meat);
                RemoveByDateAndCosher(3, Cosher.Milky);
                RemoveByDateAndCosher(1, Cosher.Pareve);
                Console.WriteLine("remove milky & meat & pareve items, note the removed item were not expiry items.\n go shopping! left place: " + leftPlace);
            }
            else
            {
                Console.WriteLine("the refrigerator is full no need for shopping");
            }
        }

        public double CountByDateAndCosher(double leftPlace, int day, Cosher cosher)
        {
            var date = DateTime.Now;
            foreach (var shelf in _shelves)
            {
                leftPlace += shelf.GetPlaceItemsByDateAndCosher(date.AddDays(day), cosher);
            }
            return leftPlace;
        }

        public void RemoveByDateAndCosher(int day, Cosher cosher)
        {
            var date = DateTime.Now;
            foreach (var shelf in _shelves)
            {
                shelf.RemoveByDateAndCosher(date.AddDays(day), cosher);
            }
            
        }
        public double SumOfPlaceByItems(List<Item> items) 
        {
            var sum = 0.0;
            foreach (var item in items)
            {
                sum += item.PlaceTaken;
            }
            return sum;
        }


    }



}








