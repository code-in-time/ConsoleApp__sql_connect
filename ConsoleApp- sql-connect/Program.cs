using System;
using System.Data.SqlClient;

namespace ConsoleApp__sql_connect
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //string connStr = "Server=myServerAddress;Database=myDataBase;User Id=myUsername; Password = myPassword; ";
            string connStr = "Server=LAPTOP-HAODD7J1\\SQLEXPRESS;Database=test;User Id=tempuser; Password = tempuser; ";

            using (var sqlConnection = new SqlConnection(connStr))
            {
                sqlConnection.Open();

                var sql = "insert into dbo.users(Id,Username,FirstName, Lastname ,IsEnabled, CreatedDateUtc, LastLoggedinDateUtc) values('uniquestring', 'user1', '2222', 'tertet', 1, '12-10-25 12:32:10 +1:00', '12-10-20 12:32:10 +1:00')";
                using (var command = new SqlCommand(sql, sqlConnection)) {

                    var result = command.ExecuteNonQuery();


                }
            }



            using (var sqlConnection = new SqlConnection(connStr))
            {
                sqlConnection.Open();
                using (var command = new SqlCommand("SELECT * FROM dbo.Users", sqlConnection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var username = reader["Username"] as string;
                            var id = reader["Id"] as string;
                            Console.WriteLine($"{username} {id}");
                        }

                        sqlConnection.Close();
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
