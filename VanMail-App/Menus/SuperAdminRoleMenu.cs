using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp_Souko
{
    public class SuperAdminRoleMenu
    {
        public SuperAdminMenuOptions SuperAdminMainMenu()
        {
            do
            {
                List<string> adminmenu = new List<string>() { "1. Create user","2. View users","3. Update user","4. Delete User","5. Sign off "};
                for (int i = 0; i < adminmenu.Count; i++) { Console.WriteLine(adminmenu[i]); }
                Console.Write("Please type 1 to 5 to select an option...");
                string superAdminChoice = Console.ReadLine();
                switch (superAdminChoice)
                {
                    case "1":
                        return SuperAdminMenuOptions.CreateUser;
                    case "2":
                        return SuperAdminMenuOptions.ReadUser;
                    case "3":
                        return SuperAdminMenuOptions.UpdateUser;
                    case "4":
                        return SuperAdminMenuOptions.DeleteUser;
                    
                    case "5":
                        return SuperAdminMenuOptions.LogOff;

                }
            } while (true);

        }
    }
}
