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
        { get { return _idRefrigerator;}
            set
            {
                _idRefrigerator = value;
            } }
      public string Model
        { get { return _model; }
            set
            {
                _model = value;
            } }
        public string Color
        { get { return _color; }
            set
            {
                _color = value;
            } }
        public int numOfShelf
        { get { return _numOfShelf; }
            set
            {
                _numOfShelf = value;
            } }
        public List<Shelf> shelves { get { return shelves; }
            set
            {
                _shelves = value;
            }

    }
}
