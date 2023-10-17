using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
            IdRefrigerator = _uniqueId++;
            Model = model;
            Color = color;
            Model = model;
            NumOfShelf = numOfShelf;
            Shelves = shelves;

        }

        public override string ToString()
        {
            return " Refrigerator : " + _idRefrigerator + " model: " + _model.ToString() + " number of shelves : " + _numOfShelf.ToString() + " the list of the shelves : " + _shelves;
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

        public bool IsEnterItem(Item item)
        {
            foreach (var shelf in _shelves)
            {
                if (shelf.AddItem(item))
                {
                    return true;

                }
            }
            return false;

        }

        public void EnterItem(Item item)
        {

            var isEntered = this.IsEnterItem(item);
            if (isEntered)
            {
                Console.WriteLine("the item added successfuly");
            }
            else
            {
                Console.WriteLine("there is no place to the otem in the refrigerator");
            }

        }

        public Item? TakeOutItem(string idItem)
        {
            var indexItem = 0;
            foreach (var shelf in _shelves)
            {
                if (shelf.IndexOfItem(idItem) != -1)
                {
                    return shelf.TakeOutItem(indexItem);
                }
            }
            return null;
        }

        public void RemoveExpiredItems()
        {
            foreach (var shelf in _shelves)
            {
                shelf.RemoveExpiredItems();
            }
        }

        public List<Item> WantToEat(string cashrot, string kind)
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
            var sortedItems = new List<Item>();
            foreach (var shelf in _shelves)
            {
                var shelfSortedItems = shelf.SortProductsByExpirationDate();
                sortedItems.AddRange(shelfSortedItems);
            }
            return sortedItems;
        }

        public List<Shelf> SortedShelvesByLeftPlace()
        {
            var sortedShelves = new List<Shelf>();
            sortedShelves = _shelves.OrderBy(shelf => shelf.PlaceLeftinShelf()).ToList();
            return sortedShelves;
        }

        public static List<Refrigerator> SortedRefrigeratorsByLeftPlace(List<Refrigerator> refrigerators)
        {
            var sortedByLeftPlace = new List<Refrigerator>();
            sortedByLeftPlace = refrigerators.OrderBy(r => r.PlaceLeftinRefrigerator()).ToList();
            return sortedByLeftPlace;

        }



    }
}
