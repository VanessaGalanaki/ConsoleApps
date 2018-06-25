using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MainApp_Souko
{
    class Program
    {
        private const string ConnectionString = "@Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = mailApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultipleActiveResultSets=true";

        static void Main(string[] args)
        {

            LogScreen logScreen = new LogScreen() { };
            DatabaseAccess databaseAccess = new DatabaseAccess() { };
            while (true)
            {
                WelcomeMenuOptions welcomeMenuOptions = logScreen.SelectWelcomeMenu();

                switch (welcomeMenuOptions)
                {

                    case WelcomeMenuOptions.SignUp:
                        bool repeat = databaseAccess.SignUpForm();
                        if (repeat == true)
                        {
                            break;
                        }
                        break;
                    case WelcomeMenuOptions.LogIn:
                        Console.Clear();
                        Console.WriteLine("Enter Username: (lower or upper doesn't count)");
                        string usernameLog = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(usernameLog))
                        {
                            bool success = databaseAccess.LogInForm(usernameLog);
                            if (success == true)
                            {

                                Console.WriteLine($"Hi {usernameLog}.");
                                //Validate the role
                                int roleResult = databaseAccess.ValidateRole(usernameLog);
                                //Show Menu for every Role 

                                if (roleResult == 3)
                                {
                                    bool repeatmenu = true;
                                    while (repeatmenu)
                                    {
                                        #region User Selection Menu
                                        UserRoleMenu appsMenu = new UserRoleMenu();
                                        UserMenuOptions userMenuOptions = appsMenu.UserMainMenu();
                                        Mail mail = new Mail();
                                        switch (userMenuOptions)
                                        {
                                            case UserMenuOptions.SendNew:
                                                Console.Clear();
                                                mail.SendMail(usernameLog);
                                                break;
                                            case UserMenuOptions.Inbox:
                                               mail.Inbox(usernameLog);
                                                Console.ReadKey();
                                                break;
                                            case UserMenuOptions.Sentbox:
                                                mail.Sent(usernameLog);
                                                break;
                                            case UserMenuOptions.LogOff:
                                                repeatmenu = false;
                                                Console.Clear();
                                                break;
                                        }
                                        #endregion
                                    }
                                }
                                else if (roleResult == 2)
                                {
                                    bool repeatadminmenu = true;
                                    while (repeatadminmenu)
                                    {
                                        #region Admin Selection Menu
                                        AdminRoleMenu arm = new AdminRoleMenu();
                                        AdminMenuOptions amo = arm.AdminMainMenu();
                                        AdminsFunctions adminsFunctions = new AdminsFunctions();
                                        switch (amo)
                                        {
                                            case AdminMenuOptions.AddUser:
                                                bool addUser = adminsFunctions.AddUser();
                                                if (addUser) break; else continue;
                                            case AdminMenuOptions.EditUsers:
                                                bool editUser = adminsFunctions.EditUser(usernameLog);
                                                if (editUser) break; else Console.Clear(); continue;
                                            case AdminMenuOptions.ViewUsers:
                                                adminsFunctions.ViewAllUsers();
                                                break;
                                            case AdminMenuOptions.ViewAllMessages:
                                                adminsFunctions.ViewAllMessages();
                                                break;
                                            case AdminMenuOptions.ViewMessagesbySender:
                                                adminsFunctions.ViewMessagebySender();
                                                break;
                                            case AdminMenuOptions.ViewMessagebyReceiver:
                                                adminsFunctions.ViewMessagebyReceiver();
                                                break;
                                            case AdminMenuOptions.LogOff:
                                                repeatadminmenu = false;
                                                Console.Clear();

                                                break;
                                            default:
                                                break;
                                        }
                                        #endregion
                                    }
                                }
                                else
                                {
                                    bool repeatSuperAdminmenu = true;
                                    while (repeatSuperAdminmenu)
                                    {
                                        #region SuperAdmin Selection Menu
                                        SuperAdminRoleMenu sarm = new SuperAdminRoleMenu();
                                        SuperAdminMenuOptions samo = sarm.SuperAdminMainMenu();
                                        SuperAdFunctions superAdFunctions = new SuperAdFunctions();
                                        switch (samo)
                                        {
                                            case SuperAdminMenuOptions.CreateUser:
                                                superAdFunctions.AddUser();
                                                break;
                                            case SuperAdminMenuOptions.ReadUser:
                                                superAdFunctions.ViewAllUsersperRole();
                                                break;
                                            case SuperAdminMenuOptions.UpdateUser:
                                                bool editUserperRole = superAdFunctions.EditUser(usernameLog);
                                                if (editUserperRole) break; else Console.Clear(); continue;
                                            case SuperAdminMenuOptions.DeleteUser:
                                                superAdFunctions.DeleteUsers(usernameLog);
                                                break;
                                            case SuperAdminMenuOptions.LogOff:
                                                Console.Clear();
                                                repeatSuperAdminmenu = false;
                                                break;
                                            default:
                                                break;
                                        }
                                        #endregion
                                    }

                                }
                                break;

                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Insert a valid username to continue.");
                        }
                        break;
                    case WelcomeMenuOptions.Exit:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }

                //Console.ReadKey();


            }
        }

    }
}
            
        
