using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace MainApp_Souko
{
    class AdminsFunctions
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
                                int roleid = 3;
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
                                Console.WriteLine($"Edit {usernametoEdit}'s Username or Password? (Type 1 to edit username or 2 to edit password)");
                                string choice = Console.ReadLine();
                                if (choice == "1")
                                {
                                    Console.WriteLine($"Edit {usernametoEdit}'s Username.");
                                    string editUsername = Console.ReadLine();
                                    using (SqlCommand cmdeditusername = new SqlCommand("Update Users set Username = @editUsername where Username = @usernametoEdit", conn))
                                    {

                                        cmdeditusername.Parameters.Add(new SqlParameter("@usernametoEdit", usernametoEdit));
                                        cmdeditusername.Parameters.Add(new SqlParameter("@editUsername", editUsername));

                                        int rows = cmdeditusername.ExecuteNonQuery();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        string rowsCreated = ($"{rows} username from database changed.");
                                        Console.WriteLine(rowsCreated);


                                    }
                                    Console.ResetColor();
                                    repeat = false;
                                    return true;

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
                            }
                        }
                        Console.WriteLine("User does not exist in database.");
                        Console.ReadKey();
                        return false;
                    }
                }

            }
        }
        public void UpdateEmailDatabase()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = mailApp; Integrated Security = True; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultipleActiveResultSets=true"))
            {
                conn.Open();
                Console.Clear();

            }
                
           
     
                                }
        public void ViewAllUsers()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = mailApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultipleActiveResultSets=true"))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("Select * from Users where RoleId= 3",conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.Clear();
                        Console.WriteLine("All users.");
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine($"UserID: " + reader.GetValue(0) + " Username " + reader.GetValue(1) + " Password " + reader.GetValue(2) + " Role ID: User " );
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.Write("No Users.");
                        }
                        Console.ResetColor();

                        Console.ReadKey();
                        Console.Clear();
                    }
                }

            }
        }
        public void ViewAllMessages()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = mailApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultipleActiveResultSets=true"))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("Select * from Email", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkYellow;

                                Console.WriteLine($"From : " + reader.GetValue(0) + " To " + reader.GetValue(1) + " Message " + reader.GetValue(2) + " Date "+ reader.GetValue(3));
                               
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("No messages");
                        }
                        Console.ResetColor();

                        Console.ReadKey();
                        Console.Clear();
                    }
                }

            }
        }
        public void ViewMessagebySender()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = mailApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultipleActiveResultSets=true"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select Sender from Email", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("[              Senders                      ]");
                        Console.ResetColor();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {


                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine(reader.GetValue(0));
                                Console.ResetColor();

                            }

                        }
                    }
                    bool repeat = true;
                    while (repeat)
                    {
                        
                        Console.WriteLine("Type sender name to view messages.");
                        string sendername = Console.ReadLine();
                        using (SqlCommand cmdSender = new SqlCommand("Select * from Email where Sender = @sendername", conn))
                        {
                            cmdSender.Parameters.Add(new SqlParameter("@sendername", sendername));
                            using (SqlDataReader readerforSender = cmdSender.ExecuteReader())
                            {
                                Console.Clear();
                                if (readerforSender.HasRows)
                                {
                                    while (readerforSender.Read())
                                    {
                                       
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine($"From : " + readerforSender.GetValue(0) + " To :  " + readerforSender.GetValue(1) + " Message :  " + readerforSender.GetValue(2) + " Date : " + readerforSender.GetValue(3));
                                        Console.ResetColor();
                                        repeat = false;
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Type sender name again.");
                                    Console.ResetColor();

                                }


                               
                            }
                        }
                        

                    }
                    Console.ReadKey();
                    Console.Clear();
                }

            }

        }
        public void ViewMessagebyReceiver()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = mailApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultipleActiveResultSets=true"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select Receiver from Email", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("[              Receivers                      ]");
                        Console.ResetColor();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {


                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine(reader.GetValue(0));
                                Console.ResetColor();

                            }

                        }
                    }

                    Console.WriteLine("Type receiver name to view messages.");
                    string receivername = Console.ReadLine();
                    using (SqlCommand cmdReceiver = new SqlCommand("Select * from Email where Receiver = @receivername", conn))
                    {
                        cmdReceiver.Parameters.Add(new SqlParameter("@receivername", receivername));
                        using (SqlDataReader readerforReceiver = cmdReceiver.ExecuteReader())
                        {
                            Console.Clear();
                            if (readerforReceiver.HasRows)
                            {
                                while (readerforReceiver.Read())
                                {
                                    
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine($"From : " + readerforReceiver.GetValue(0) + " To :" + readerforReceiver.GetValue(1) + " Message :" + readerforReceiver.GetValue(2) + " Date: " + readerforReceiver.GetValue(3));

                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Type receiver name again.");
                            }


                            Console.ResetColor();

                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                }

            }

        }
    }
}
