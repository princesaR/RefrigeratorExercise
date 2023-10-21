using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorProject
{
    public class Shelf
    {
        private static int _Id = 0;
        private string _idShelf;

        private int _numOfShelfLevel;

        private double _placeInShelf;
        private double _currentPlace;

        private List<Item> _Items;

        public string IdShelf
        {
            get { return _idShelf; }
            private set
            {
                _idShelf = value;
            }
        }
        public int NumOfShelfLevel
        {
            get { return _numOfShelfLevel; }
            set
            {
                _numOfShelfLevel = value;
            }
        }
        public double PlaceInShelf
        {
            get { return _placeInShelf; }
            set
            {
                _placeInShelf = value;
            }
        }
        public double CurrentPlace
        {
            get { return _currentPlace; }
            set
            {

                if (value <= _placeInShelf && value >= 0)
                {
                    _currentPlace = value;
                }
                else
                {
                    throw new Exception("Attempting to add an item larger than the current remaining space");
                }

            }
        }

        public List<Item> Items
        {
            get { return _Items; }
            set
            {
                _Items = value;
            }
        }

        public Shelf(int numOfShelfLevel, double placeInShelf, List<Item> items)
        {
            IdShelf = (++_Id).ToString();
            NumOfShelfLevel = numOfShelfLevel;
            PlaceInShelf = placeInShelf;
            Items = new List<Item>();
            Items = items;
        }

        
        public override string ToString()
        {
            var result = "";
            result += "shelf: " + _idShelf + ", the level of the shelf: " + _numOfShelfLevel.ToString() + ", place in shelf: " + _placeInShelf;
            if (_Items.Count() == 0)
            {
                result += ", there is no items in this shelf.";
            }
            else
            {
                result += " the items in the shelf : \n";
                foreach (var item in Items)
                {
                    result += (item.ToString())+"\n";
                }
            }

            return result;
        }

        public double PlaceLeftinShelf()
        {
            var placeTakenByItems = 0.0d;
            foreach (var item in _Items)
            {
                placeTakenByItems += item.PlaceTaken;
            }
            return _placeInShelf - placeTakenByItems;
        }

        public bool IsLeftPlaceFor(Item item)
        {
            var leftPlace = PlaceLeftinShelf();
            if (item.PlaceTaken > leftPlace)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool EnterItem(Item item)
        {
            var isEnter = IsLeftPlaceFor(item);

            if (!isEnter)
            {
                return false;
            }

            _Items.Add(item);
            item.Shelf = this;
            return true;
        }

        public int IndexOfItem(string idItem)
        {
            for (var index = 0; index < _Items.Count; index++)
            {
                if (_Items[index].IdItem == idItem)
                {
                    return index;
                }
            }
            return -1;
        }
        public Item TakeOutItem(int indexItem)
        {
            var item = _Items[indexItem];
            _Items.RemoveAt(indexItem);
            return item;
        }

        public List<Item> RemoveExpiredItems()
        {
            var now = DateTime.Now.AddDays(-1);
            var removedItem = new List<Item>();

            foreach (var item in _Items)
            {
                if (item.ExpiryDate < now)
                {

                    removedItem.Add(item);

                }
            }
            _Items.RemoveAll(item => item.ExpiryDate < now);
            return removedItem;
        }


        public List<Item> ItemsWithSpesific(Cosher cashrot, Kind kind)
        {
            List<Item> itemsWithSpesific = new List<Item>();
            foreach (var item in _Items)
            {
                if (item.Cosher == cashrot && item.KindOfItem == kind && item.IsNotExpiredItem())

                {
                    itemsWithSpesific.Add(item);
                }
            }
            return itemsWithSpesific;
        }

        public double GetPlaceItemsByDateAndCosher(DateTime date, Cosher cosher)
        {

            var leftPlace = 0.0;
            foreach (var item in _Items)
            {
                if (item.ExpiryDate < date && item.Cosher == cosher)
                {

                    leftPlace += item.PlaceTaken;
                }
            }
            return leftPlace;
        }

        public void RemoveByDateAndCosher(DateTime date, Cosher cosher)
        {

            _Items.RemoveAll(item => item.ExpiryDate < date && item.Cosher == cosher);
        }


    }

}
