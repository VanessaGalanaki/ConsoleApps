using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace MainApp_Souko
{
    public class Mail
    {
        

        public void SendMail(string usernameLog)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = mailApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultipleActiveResultSets=true"))
            {
                conn.Open();
                #region Mail Input from user
                Console.WriteLine("Give me the user: ");
                string receiver = Console.ReadLine();
                using (SqlCommand cmdcheckifexists = new SqlCommand("Select Count(*) from Users where Username = @receiver", conn))
                {
                    
                    cmdcheckifexists.Parameters.Add(new SqlParameter("@receiver", receiver));

                    int UserExists = (int)cmdcheckifexists.ExecuteScalar();
                    if (UserExists > 0)
                    {

                        Console.WriteLine("Main Body ");
                        string mainBody = Console.ReadLine();
                        DateTime dateTime = DateTime.Now;

                        #endregion

                        using (SqlCommand cmd = new SqlCommand("Insert Email (Sender , Receiver , MainBody, DateTime) Values (@username, @receiver,@mainBody,@dateTime)", conn))
                        {
                            cmd.Parameters.Add(new SqlParameter("username", usernameLog));
                            cmd.Parameters.Add(new SqlParameter("receiver", receiver));
                            cmd.Parameters.Add(new SqlParameter("mainBody", mainBody));
                            cmd.Parameters.Add(new SqlParameter("dateTime", dateTime));


                            int rows = cmd.ExecuteNonQuery();
                            Console.WriteLine($"{rows} message sent");
                        }
                    }
                    else { Console.WriteLine($"User {receiver} does not exist."); }

                }
            }
        }
        public void Inbox(string usernameLog)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = mailApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultipleActiveResultSets=true"))
            {
                conn.Open();
                using (SqlCommand cmdMessages = new SqlCommand("SELECT * FROM Email where Receiver = @usernameLog", conn))
                {
                    cmdMessages.Parameters.Add(new SqlParameter("@usernameLog", usernameLog));

                    using (SqlDataReader reader = cmdMessages.ExecuteReader())
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;

                        Console.WriteLine("[         Inbox            ]");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkRed;



                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                Console.WriteLine($"From : " + reader.GetValue(0) + " " + "Message:" + reader.GetValue(2) + " " + reader.GetValue(3));

                            }
                        }
                        else
                        {
                           

                            Console.WriteLine("No messages.");
                            
                        }
                        Console.ResetColor();


                    }

                }
            }
        }

        public void Sent(string usernameLog)
        {
            
                using (SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = mailApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultipleActiveResultSets=true"))
                {
                    conn.Open();
                using (SqlCommand cmdMessages = new SqlCommand("SELECT * FROM Email where Sender = @usernameLog", conn))
                {
                    cmdMessages.Parameters.Add(new SqlParameter("@usernameLog", usernameLog));
                    
                    using (SqlDataReader reader = cmdMessages.ExecuteReader())
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("[         My messages.         ]");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;

                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                Console.WriteLine("Send to: " + reader.GetValue(1) + " " + "Message:" + reader.GetValue(2) + " " + reader.GetValue(3));
                            }
                        }
                        else
                        {
                            Console.Write("No messages sent.");
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


