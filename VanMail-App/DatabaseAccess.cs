using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace MainApp_Souko
{
    public class DatabaseAccess
    {
        public bool SignUpForm()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = mailApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultipleActiveResultSets=true"))
            {
                conn.Open();
                Console.Clear();
                #region Sign Up
                Console.WriteLine("Select Username");
                string username = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(username))
                {
                    using (SqlCommand cmdSignUp = new SqlCommand("Select Count(*) from Users where Username = @username", conn))
                    {
                        cmdSignUp.Parameters.Add(new SqlParameter("username", username));
                        int UserExists = (int)cmdSignUp.ExecuteScalar();
                        if (UserExists > 0)
                        {

                            string errorMessage = "Username already exists. Please sign up again";

                            Console.WriteLine(errorMessage);
                            return false;

                        }
                        else
                        {

                            Console.WriteLine("Enter a password, 6-8 characters");
                            string password = Console.ReadLine();
                            if (password.Length<=8 && password.Length>=6)
                            {
                                int roleid = 3;
                                using (SqlCommand cmdPass = new SqlCommand("Insert into Users(Username, Password, RoleID) Values(@username, @password, @roleid)", conn))
                                {

                                    cmdSignUp.Parameters.Add(new SqlParameter("@username", username));
                                    cmdPass.Parameters.Add(new SqlParameter("@username", username));
                                    cmdPass.Parameters.Add(new SqlParameter("@password", password));
                                    cmdPass.Parameters.Add(new SqlParameter("@roleid", roleid));


                                    int rows = cmdPass.ExecuteNonQuery();
                                    string rowsCreated = ($"{rows} new user has been created. Press a key to go back to Main Menu and LogIn");
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
                #endregion
                else
                {
                    Console.WriteLine("Try entering a valid username. (Does not accept space as an username)");
                    return false;
                }
                
               
            }
                
        }
        public bool LogInForm(string usernameLog)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = mailApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultipleActiveResultSets=true"))
            {
                    conn.Open();
                    Console.CursorVisible = true;
                    #region LogIn
                    //Console.WriteLine("Enter Username:");
                    //usernameLog = Console.ReadLine();
                    Console.WriteLine("Enter Password:");
                    string passwordLog = Console.ReadLine();

                #endregion
                 
                    using (SqlCommand cmdLogin = new SqlCommand("SELECT 1 FROM Users where Username = @usernameLog and Password= @passwordLog ", conn))
                    {

                        cmdLogin.Parameters.Add(new SqlParameter("usernameLog", usernameLog));
                        cmdLogin.Parameters.Add(new SqlParameter("passwordLog", passwordLog));
                        using (SqlDataReader reader = cmdLogin.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                Console.WriteLine("Access ok");
                                
                                Console.Clear();
                                
                                return true;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine($"Try again. No such user or wrong password. \nPress any key to continue...");
                                
                                return false;
                                
                            }
                            



                        }
                    }
                       
            }
        }

        public int ValidateRole(string usernameLog)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = mailApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultipleActiveResultSets=true"))
            {
                conn.Open();

                using (SqlCommand cmdValid = new SqlCommand("Select RoleID from Users where Username = @usernameLog ", conn))
                {

                    cmdValid.Parameters.Add(new SqlParameter("usernameLog", usernameLog));
                     var roleResult = (Int32)cmdValid.ExecuteScalar();
                      return roleResult;
                }
                       
            }
        }


    }

}

