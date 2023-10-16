﻿using System;
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

        private List<Item> _Items;

        public string IdShelf
        {
            get { return _idShelf; }
            set
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
            NumOfShelfLevel = numOfShelfLevel;
            PlaceInShelf = placeInShelf;
            Items = items;
        }

        public override string ToString()
        {
            return " shelf: " + _idShelf + " the level of the shelf: " + _numOfShelfLevel.ToString() + " place in shelf: " + _placeInShelf + " the items in the shelf : " + _shelfItems;
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

        public bool LeftPlaceFor(Item item)
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

        public bool AddItem(Item item)
        {
            var isEnter = LeftPlaceFor(item);

            if (!isEnter)
            {
                return false;
            }

            _Items.Add(item);
            item.IdShelfOfItem = _idShelf;
            return true;
        }

    }
}
