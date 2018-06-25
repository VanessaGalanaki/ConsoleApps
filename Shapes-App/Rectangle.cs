using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes_Ex2_VGalanaki
{
    class Rectangle : Shape ,IComparable, IEquatable<Rectangle>
    {   //members/
        //fields
        protected double _width;
        protected double _height;
        private string _name;
        //properties
        public double Width { get { return _width; } }
        public double Height { get { return _height; } }
        
       
        //constructor
        public Rectangle(double width, double height, string name)
        {
            this._width = width;
            this._height = height;
            this._name = name;
        }

       
        //GetInfo method
        public override string GetInfo()
       {
            string infoRect = ($"{_name} of {Color},width {_width},height {_height}");
            return infoRect;
        }
        //Override ToString Method
        public override string ToString()
        {
          return GetInfo();
        } 
        //GetArea//
        public virtual double GetArea()
        {
            
            return _width*_height;
        }
        //CompareTo #not functional
        public int CompareTo(object other)
        {
            if (other ==null)
            {
                throw new ArgumentNullException();
                
            }
            return string.Compare(Width*Height, other.Width*Height,true);

        }
        //Equal implementation
         public override bool Equals(object obj)
        {
            Rectangle other = obj as Rectangle;
            if (other !=null && other.Id==this.GetArea)
            {
                return true;
            }
            return false;
           
        }
        public bool Equals(Rectangle other)
        {
            return Equals((object)other);
        }
        
    }
}
