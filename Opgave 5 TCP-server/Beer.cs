using System;
using System.Collections.Generic;
using System.Text;

namespace Opgave_5_TCP_server
{
    public class Beer
    {

        private string _name;
        private int _price;
        private int _abv;
        private int _id;

        public int Id
        {
            get => _id;
            set => _id = value;
        }
        public string Name
        {
            get => _name;
            set
            {
                if (value.Length < 4) { throw new ArgumentException(); }
                _name = value;
            }
        }
        public int Price
        {
            get => _price;
            set
            {
                if (value < 0) { throw new ArgumentOutOfRangeException(); }
                _price = value;

            }
        }
        public int Abv
        {
            get => _abv;
            set
            {
                if (value < 0 || value > 100) { throw new ArgumentOutOfRangeException(); }
                _abv = value;
            }
        }

        public override string ToString()
        {
            return Name + " " + Price;
        }

        public Beer(int Id, string Name, int Price, int Abv)
        {
            _id = Id;
            _name = Name;
            _price = Price;
            _abv = Abv;
        }
        public Beer()
        {

        }
    }
}
