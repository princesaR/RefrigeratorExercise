using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorProject
{
    public class Shelf
    {
        private string _idShelf;

        private int _numOfShelfLevel;

        private double _placeInShelf;

        private List<Item> _shelfItems;

        public string IdShelf
        { get { return _idShelf; }
            set
            {
                _idShelf = value;
            } }
        public int NumOfShelfLevel
        { get { return _numOfShelfLevel;}
            set
            {
                _numOfShelfLevel = value;
            } }
        public double PlaceInShelf
        { get { return _placeInShelf;}
            set
            {
                _placeInShelf = value;
            } }
        public List<Item> ShelfItems
        { get { return _shelfItems; }
            set
            {
                _shelfItems = value;
            } }
    }
}
