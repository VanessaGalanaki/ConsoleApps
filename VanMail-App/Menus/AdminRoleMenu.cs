using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp_Souko
{
    public class AdminRoleMenu
    {
        public AdminMenuOptions AdminMainMenu()
        {
            do
            {
                List<string> adminmenu = new List<string>() { "1. Create User", "2. Update Users", "3. View Users ", "4. View all messages ", "5. View messages by sender","6. View message by receiver", "7. Log off" };
                for (int i = 0; i < adminmenu.Count; i++) { Console.WriteLine(adminmenu[i]); }
                Console.Write("Please type a number 1-7 to select an option...");
                string AdminChoice = Console.ReadLine();
                switch (AdminChoice)
                {
                    case "1":
                        return AdminMenuOptions.AddUser;
                    case "2":
                        return AdminMenuOptions.EditUsers;
                    case "3":
                        return AdminMenuOptions.ViewUsers;
                    case "4":
                        return AdminMenuOptions.ViewAllMessages;
                    case "5":
                        return AdminMenuOptions.ViewMessagesbySender;
                    case "6":
                        return AdminMenuOptions.ViewMessagebyReceiver;
                    case "7":
                        return AdminMenuOptions.LogOff;


                }
            } while (true);

        }

    }
}
