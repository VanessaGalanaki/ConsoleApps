using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp_Souko
{
    public class UserRoleMenu
    {
        public UserMenuOptions UserMainMenu()
        {
            do
            {
                List<string> welcomeMenu = new List<string>() { "1. Send new mail", "2. Inbox", "3. Sent", "4. Log Off" };
                #region Colors
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(welcomeMenu[0]); Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(welcomeMenu[1]); Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(welcomeMenu[2]); Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(welcomeMenu[3]); Console.ResetColor();
                #endregion 
                Console.Write("Please type 1 or 2 or 3 or 4 to select an option...");
                string Userschoice = Console.ReadLine();
                switch (Userschoice)
                {
                    case "1":
                        return UserMenuOptions.SendNew;
                    case "2":
                        return UserMenuOptions.Inbox;
                    case "3":
                        return UserMenuOptions.Sentbox;
                    case "4":
                        return UserMenuOptions.LogOff;
                    
                } 


            } while (true);
        }

        

    }
}
