using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExercise
{
    class Car
    {
        private string _brand;
        private string _model;
        public Color color { get; set; } //property color (enum)
        public string brand { get { return _brand; } } //property brand
        public string model { get { return _model; } } // property model
        public Engine engine { get; set; }

        public void Accelarate()// method Accelarate
        {
            int newspeed = 0;
            int currentspeed = 0;
            Console.WriteLine("What's your speed right now?");
            newspeed = int.Parse(Console.ReadLine()); //ζητάει από τον χρήστη την ταχύτητα
            for (int i = 0; i < newspeed; i++)// no exception yet,soon to be added
            {
                Console.WriteLine(i + 1); // εμφανίζει την επιτάχυνση της ταχύτητας 
                currentspeed = newspeed;
                
            }
               
            if (newspeed>120)//ελέγχει την συνθήκη
            {
                    Console.WriteLine("Slow down... The limit is 120 km/h");

            }
            else
            {
                Console.WriteLine("Keep going");
                     
            }
        }
        public void Stop() // method Stop
        {
            Console.WriteLine("Ready to stop the engine, what's your speed?");
            int speed = int.Parse(Console.ReadLine());
            for (int j = 0; j <=speed; j++)// προαιρετικό στάδιο εμφανίζει την μείωση της ταχύτητας
            {
                Console.WriteLine(speed-j);
            }
                if (speed > 0)// ελέγχει τη συνθήκη 
                {
                    speed = 0;
                    Console.WriteLine("The car has now stopped");
                }
                else
                {
                    Console.WriteLine($"Your speed is {speed}, you are already stopped.");
                }

            
            
        }
        public Car(Color color,string brand, string model)// constructor
        {   
            _brand = brand;
            _model = model;
        }
    }
}
