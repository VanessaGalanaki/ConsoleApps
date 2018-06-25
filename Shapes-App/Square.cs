using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes_Ex2_VGalanaki
{
    sealed class Square : Rectangle ,IComparable
    {
        //Members
        //Fields
        private string _name;
        
        //Constructor
        public Square(double width, double height,string name) : base(width, height,name)
        {
            this._name = name;

        }
        //GetInfo Method
        public override string GetInfo()
        {
            //Console.WriteLine($"{_name} of {Color},side lenght {Width}");
            string infoSq = ($"{_name} of {Color},side lenght {Width}");
            return infoSq;
        }
        //ToString Method
        public override string ToString()
        {
            return GetInfo();
        }
       
        
    }
}
