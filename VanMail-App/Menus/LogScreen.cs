using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp_Souko
{
    public class LogScreen
    {
        public WelcomeMenuOptions SelectWelcomeMenu()
        {
            Random _random = new Random();
            do
            {
                List<string> welcomeMenu = new List<string>() { "1. Sign Up", "2. Log In", "3. Exit" };
                #region Colors
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(welcomeMenu[0]); Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(welcomeMenu[1]); Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(welcomeMenu[2]); Console.ResetColor();
                #endregion 
                Console.Write("Please type 1 or 2 or 3 to select an option...");
                string choice = Console.ReadLine();
                switch (choice)
                {                    
                    case "1":
                        return WelcomeMenuOptions.SignUp;
                    case "2":
                        return WelcomeMenuOptions.LogIn;

                    case "3":
                        return WelcomeMenuOptions.Exit;
                    default:
                        Console.Clear();
                        break;
                }

            } while (true);
        }


        
    }
}
