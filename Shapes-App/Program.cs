using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes_Ex2_VGalanaki
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            //new rectangle Objects
            Rectangle r1 = new Rectangle(15,18,"Rectangle");
            Rectangle r2 =new Rectangle(19,24,"Rectangle");
            //Equals r1 to r2
            bool equals = r1.Equals(r2);
            Console.WriteLine(equals);
            //GetInfo +ToString
            Console.WriteLine(r1.GetInfo());
            Square sq1 = new Square(20, 0, "Square");
            Console.WriteLine(sq1.GetInfo());
            Console.WriteLine(r1.ToString());
            Console.WriteLine(sq1.ToString());
            /////////////////////////////////////////////////////////
            //List Items of Rectangle
            List<Rectangle> RectanglesList =new List<Rectangle>();
            RectanglesList.Add(new Rectangle(){15,18,"Rectangle"});
            RectanglesList.Add(new Rectangle(){15,25,"Rectangle"});
            RectanglesList.Add(new Rectangle(){35,18,"Rectangle"});
            RectanglesList.Add(new Rectangle(){75,50,"Rectangle"});
            RectanglesList.Add(new Rectangle(){200,108,"Rectangle"});

            //////////////////////////////////////////////////////////
            //Sort Items
            RectanglesList.Sort();

            Console.ReadKey();
        }

        
        
       
        
    }
}
