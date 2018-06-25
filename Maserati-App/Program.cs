using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is a test drive (press enter to show info)");//εισαγωγικό μνμ
            Console.ReadKey();

            Car Amaksara = new Car(Color.NavyBlue, "Maserati", "Alfieri"); //αρχικοποίηση του Amaksara ως Car
            Console.WriteLine($"Family of {Amaksara.brand} is welcoming you");// εμφάνιση της μάρκας
            Console.WriteLine($"The car is {Color.NavyBlue}"); // εμφάνιση του χρώματος
            Console.WriteLine($"This {Amaksara.model} is ready to start (press enter to begin)"); // εμφάνιση του μοντέλου
            Console.ReadKey();

            Amaksara.Accelarate();//ξεκινάει η method της επιτάχυνσης
            Amaksara.Stop(); //method του stop
            Console.ReadKey();
        }
    }
}
