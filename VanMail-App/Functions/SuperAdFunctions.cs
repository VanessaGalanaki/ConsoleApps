using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace MainApp_Souko
{
    public class SuperAdFunctions
    {
        public bool AddUser()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = mailApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultipleActiveResultSets=true"))
            {
                conn.Open();
                Console.Clear();
                Console.WriteLine("Select Username");
                string usernametoAdd = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(usernametoAdd))
                {
                    using (SqlCommand cmdAddUser = new SqlCommand("Select Count(*) from Users where Username = @usernametoAdd", conn))
                    {
                        cmdAddUser.Parameters.Add(new SqlParameter("@usernametoAdd", usernametoAdd));
                        int UserExists = (int)cmdAddUser.ExecuteScalar();
                        if (UserExists > 0)
                        {

                            string errorMessage = "Username already exists. Please try again";
                            Console.WriteLine(errorMessage);
                            Console.ReadKey();
                            Console.Clear();
                            return false;

                        }
                        else
                        {

                            Console.WriteLine("Enter a password, 6-8 characters");
                            string password = Console.ReadLine();
                            if (password.Length <= 8 && password.Length >= 6)
                            {
                                    Console.WriteLine("Pick a role.");
                                    List<string> roles = new List<string>() { "1.  Moderator", "2. Administrator", "3. User" };
                                for (int i = 0; i < roles.Count; i++)
                                {
                                    Console.WriteLine(roles[i]);
                                }
                                    int roleid = int.Parse(Console.ReadLine());
                                if (roleid<=3)
                                {

                                    using (SqlCommand cmdPass = new SqlCommand("Insert into Users(Username, Password, RoleID) Values(@username, @password, @roleid)", conn))
                                    {

                                        cmdAddUser.Parameters.Add(new SqlParameter("@username", usernametoAdd));
                                        cmdPass.Parameters.Add(new SqlParameter("@username", usernametoAdd));
                                        cmdPass.Parameters.Add(new SqlParameter("@password", password));
                                        cmdPass.Parameters.Add(new SqlParameter("@roleid", roleid));


                                        int rows = cmdPass.ExecuteNonQuery();
                                        string rowsCreated = ($"{rows} new user has been created. Press a key to go back to Main Menu");
                                        Console.WriteLine(rowsCreated);

                                        return true;


                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Select between 1-3");
                                    return false;
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine("Password must contain 6 - 8 characters.");
                                return false;
                            }

                        }

                    }

                }

                else
                {
                    Console.WriteLine("Try entering a valid username. (Does not accept space as an username)");
                    return false;
                }


            }
        }
        public void ViewAllUsersperRole()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = mailApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultipleActiveResultSets=true"))
            {
                conn.Open();
                Console.Clear();
                
                Console.WriteLine("Type role to view users.");
                int roleid = int.Parse(Console.ReadLine());
                if (roleid <= 3)
                {
                    using (SqlCommand cmd = new SqlCommand("Select * from Users where RoleId=@roleid", conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@roleid", roleid));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.Clear();
                            if (reader.HasRows)
                            {

                                while (reader.Read())
                                {

                                    Console.WriteLine($"UserID: " + reader.GetValue(0) + " Username " + reader.GetValue(1) + " Password " + reader.GetValue(2) + " Role ID: User ");

                                }
                            }
                            else
                            {
                                Console.Write("No Users.");
                            }
                            Console.ResetColor();

                        }
                    }
                }
                else
                {
                    Console.WriteLine("Pick 1.Moderator, 2.Administrator, 3.User");
                }


                Console.ReadKey();
                Console.Clear();
            }
        }
            public bool EditUser(string usernameLog)
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = mailApp; Integrated Security = True; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultipleActiveResultSets=true"))
                {
                    conn.Open();
                    Console.Clear();

                    Console.WriteLine("Type a username, you like to edit");
                    string usernametoEdit = Console.ReadLine();
                    if (usernametoEdit == usernameLog)
                    {
                        Console.WriteLine("You can't change your own username. ");
                        Console.ReadKey();
                        Console.Clear();
                        return false;
                    }
                    else
                    {
                        using (SqlCommand cmdedituser = new SqlCommand("Select Count(*) from Users where Username = @usernametoEdit", conn))
                        {
                            cmdedituser.Parameters.Add(new SqlParameter("@usernametoEdit", usernametoEdit));

                            int UserExists = (int)cmdedituser.ExecuteScalar();
                            if (UserExists > 0)
                            {
                                bool repeat = true;
                                while (repeat)
                                {
                                    Console.WriteLine($"Edit {usernametoEdit}'s Username or Password or Role? (Type 1 to edit username or 2 to edit password or 3 to edit role)");
                                    string choice = Console.ReadLine();
                                    if (choice == "1")
                                    {
                                        Console.WriteLine($"Edit {usernametoEdit}'s Username.");
                                        string editUsername = Console.ReadLine();
                                        using (SqlCommand cmdeditusername = new SqlCommand("Update Users set Username = @editUsername where Username = @usernametoEdit", conn))
                                        {
                                            cmdedituser.Parameters.Add(new SqlParameter("@usernametoEdit", usernametoEdit));
                                            cmdeditusername.Parameters.Add(new SqlParameter("@usernametoedit", usernametoEdit));
                                            cmdeditusername.Parameters.Add(new SqlParameter("@editUsername", editUsername));

                                            int rows = cmdeditusername.ExecuteNonQuery();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            string rowsCreated = ($"{rows} username from database changed.");
                                            Console.WriteLine(rowsCreated);
                                            Console.ResetColor();
                                            repeat = false;
                                            return true;
                                        }
                                    }
                                    else if (choice == "2")
                                    {
                                        Console.WriteLine($"Edit {usernametoEdit}'s Password.");
                                        string editPassword = Console.ReadLine();
                                        using (SqlCommand cmdeditPassword = new SqlCommand("Update Users set Users.Password = @editPassword where Username = @usernametoEdit", conn))
                                        {
                                            cmdedituser.Parameters.Add(new SqlParameter("@usernametoEdit", usernametoEdit));
                                            cmdeditPassword.Parameters.Add(new SqlParameter("@usernametoedit", usernametoEdit));
                                            cmdeditPassword.Parameters.Add(new SqlParameter("@editPassword", editPassword));
                                            int rows = cmdeditPassword.ExecuteNonQuery();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            string rowsCreated = ($"{rows} password from database changed.");
                                            Console.WriteLine(rowsCreated);
                                            Console.ResetColor();
                                            repeat = false;
                                            return true;
                                        }
                                    }
                                else
                                {
                                    Console.WriteLine($"Edit {usernametoEdit}'s Role.");
                                    string editRole = Console.ReadLine();
                                    using (SqlCommand cmdeditRole = new SqlCommand("Update Users set Users.RoleID = @editRole where Username = @usernametoEdit", conn))
                                    {
                                        cmdedituser.Parameters.Add(new SqlParameter("@usernametoEdit", usernametoEdit));
                                        cmdeditRole.Parameters.Add(new SqlParameter("@usernametoedit", usernametoEdit));
                                        cmdeditRole.Parameters.Add(new SqlParameter("@editRole", editRole));
                                        int rows = cmdeditRole.ExecuteNonQuery();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        string rowsCreated = ($"{rows} role from database changed.");
                                        Console.WriteLine(rowsCreated);
                                        Console.ResetColor();
                                        repeat = false;
                                        return true;
                                    }
                                }
                                }
                            }
                            Console.WriteLine("User does not exist in database.");
                            Console.ReadKey();
                            return false;
                        }
                    }

                }
            }

        public void DeleteUsers(string usernameLog)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = mailApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultipleActiveResultSets=true"))
            {
                conn.Open();
                Console.Clear();
                Console.WriteLine("Delete users per name. Enter name of user.");
                string userexist = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(userexist))
                {
                    using (SqlCommand cmdDelete = new SqlCommand("Select Count(*) from Users where Username= @userexist", conn))
                    {
                        cmdDelete.Parameters.Add(new SqlParameter("@userexist", userexist));
                        int UserExists = (int)cmdDelete.ExecuteScalar();
                        if (UserExists > 0)
                        {
                            using (SqlCommand cmdfinalDelete =new SqlCommand("Delete from Users where Username = @userexist",conn))
                            {
                                cmdDelete.Parameters.Add(new SqlParameter("@userexist", userexist));

                                cmdfinalDelete.Parameters.Add(new SqlParameter("@userexist", userexist));
                                
                                int rows = cmdfinalDelete.ExecuteNonQuery();
                                Console.ForegroundColor = ConsoleColor.Green;
                                string rowsCreated = ($"{rows} role from database changed.");
                                Console.WriteLine(rowsCreated);
                                Console.ResetColor();
                              
                            }

                        }
                        else
                        {
                            Console.WriteLine("User does not exist.");
                        }
                        

                    }

                }
            }
        }
    }
}
