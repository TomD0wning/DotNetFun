using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetFun
{
    public class Food
    {
        private string _name;
        private string _colour;
        private int _daysOld;
        public string Name { get { return _name; }  }
        public string Colour { get { return _colour; } }
        public int DaysOld { get { return _daysOld; } }



        public Food(string name)
        {
            _name = name;
        }

        public Food(string name, string colour)
        {
            _name = name;
            _colour = colour;
        }

        public Food(string name, string colour, int age)
        {
            _name = name;
            _colour = colour;
            _daysOld = age;

        }


        public override string ToString()
        {
            return _name;
        }





    }
}
