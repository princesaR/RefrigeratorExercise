using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorProject
{
    public class Refrigerator
    {
        private string _idRefrigerator;
        private string _model;
        private string _color;
        private int _numOfShelf;
        private List<Shelf> _shelves;

        public string IdRefrigerator
        {
            get { return _idRefrigerator; }
            set
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
        }
    }
}
