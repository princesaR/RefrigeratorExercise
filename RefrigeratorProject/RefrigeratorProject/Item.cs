using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorProject
{
    public enum Cosher
    {
        Milky =1,
        Meat,
        Pareve
    }

    public enum Kind
    {
        Food =1,
        Drink
    }
    
    public class Item
    {
        private static int _Id =0;
        private string _idItem;
        private string _nameItem;
        private Shelf shelf;
        private Kind _kindOfItem;
        private Cosher _cosher;
        private DateTime _expiryDate;
        private double _placeTaken;

        public string IdItem
        {
            get { return _idItem; }
            private set
            {
                _idItem = value;
            }
        }
        public string NameItem
        {
            get { return _nameItem; }
            set
            {
                _nameItem = value;
            }
        }
        public Shelf Shelf
        {
            get { return shelf; }
            set
            {
                shelf = value;
            }
        }
        public Kind KindOfItem
        {
            get { return _kindOfItem; }
            set
            {
                _kindOfItem = value;
            }
        }
        public Cosher Cosher
        {
            get { return _cosher; }
            set
            {
                _cosher = value;
            }
        }
        public DateTime ExpiryDate
        {
            get { return _expiryDate; }
            set
            {
                _expiryDate = value;
            }
        }
        public double PlaceTaken
        {
            get { return _placeTaken; }
            set
            {
                _placeTaken = value;
            }
        }

        public Item(string nameItem,Kind kindOfItem, Cosher cosher, DateTime expiryDate, double placeTaken)
        {
            IdItem = (++_Id).ToString();
            NameItem = nameItem;
            KindOfItem = kindOfItem;
            Cosher = cosher;
            ExpiryDate = expiryDate;
            PlaceTaken = placeTaken;

        }

        public override string ToString()
        {
            var result = "Item id: " + _idItem + ", name: " + _nameItem  + ", kind: " + _kindOfItem + ", cashtot: " + _cosher.ToString() + ", expery date: " + _expiryDate.ToString() + ", place taken by item: " + _placeTaken;
            return result;
        }

        public bool IsNotExpiredItem()
        {
            if (this.ExpiryDate < DateTime.Now)
            {
                return false;
            }
            return true;
        }

    }
}
