using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorProject
{
    public class Item
    {
        private string _idItem;
        private string _nameItem;
        private string _idShelfOfItem; 
        private string _kindOfItem;
        private string _cashrot;
        private DateTime _expiryDate;
        private double _placeTaken;

        public string IdItem
        { get { return _idItem; } 
            set 
            { 
                _idItem = value;
            } }
        public string NameItem
        { get { return _nameItem; } 
            set
            { 
                _nameItem = value; 
            } }
        public string IdShelfOfItem
        { get { return IdShelfOfItem; }
            set
            {
                IdShelfOfItem = value;
            } }
        public string KindOfItem
        { get { return _kindOfItem; }
            set
            { _kindOfItem = value; 
            } }
        public string Cashrot
        { get { return _cashrot; }
            set
            {
                _cashrot = value;
            } }
        public DateTime ExpiryDate
        { get { return _expiryDate; }
            set
            {
                _expiryDate = value;
            } }
        public double PlaceTaken
        { get { return _placeTaken;}
            set
            {
                _placeTaken = value;
            } }
       
        public Item(string idItem, string nameItem, string idShelfOfItem, string kindOfItem, string cashrot, DateTime expiryDate, double placeTaken)
        {
            
            NameItem = nameItem;
            IdShelfOfItem = idShelfOfItem;
            KindOfItem = kindOfItem;
            Cashrot = cashrot;
            ExpiryDate = expiryDate;
            PlaceTaken = placeTaken;
           
        }

        public override string ToString()
        {
            return "Item id: " + _idItem + " name: " + _nameItem + " in shelf: " + IdShelfOfItem + " kind: " + _kindOfItem + " cashtot: " + _cashrot + " expery date: " + _expiryDate.ToString() + " place taken by item: " + _placeTaken.ToString();
        }
    }
}
