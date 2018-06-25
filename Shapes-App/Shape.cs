using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes_Ex2_VGalanaki
{
    abstract class Shape
    {
        //members
        //fileds
        protected ShapeColor Color { get; set;}
        //Method
        public ShapeColor SetColor() 
        {
            return ShapeColor.Red;
        }
        //GetInfo Abstract Method
        public abstract string GetInfo();
        //Constructor
        public Shape(ShapeColor color)
        {
            Color = color;
        }
        //Default Constructor
        public Shape(){}
       
    }
}
