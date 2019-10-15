using System;
using System.Data.SqlClient;
using static System.Console;

namespace AdoNet
{
    public class AdoNetTools
    {
        static void Main(string[] args)
        {
            WriteLine("Library\n");
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true";
                connection.Open();
                ShowConnectionStatus(connection);
                string sql = "Select * From book;";
                using (SqlCommand myCommand = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                    {
                        do
                        {
                            while (myDataReader.Read())
                            {
                                WriteLine("***** Запис *****");
                                for (int i = 0; i < myDataReader.FieldCount; i++)
                                {
                                    WriteLine($"{myDataReader.GetName(i)} = {myDataReader.GetValue(i)}");
                                }
                                WriteLine();
                            }
                        } while (myDataReader.NextResult());
                    }
                }
                connection.Close();
            }
            ReadLine();

        }
        static void ShowConnectionStatus(SqlConnection connection)
        {
            // Show various stats about current connection object.
            WriteLine("***** Info about your connection *****");
            WriteLine($"Database location: {connection.DataSource}");
            WriteLine($"Database name: {connection.Database}");
            WriteLine($"Timeout: {connection.ConnectionTimeout}");
            WriteLine($"Connection state: {connection.State}\n");
        }
        #region Delete Tools
        public static void DeleteBook(int Id)
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true";
                connection.Open();
                string sql = "Delete from book where book.Id = " + Id.ToString();
                using (SqlCommand myCommand = new SqlCommand(sql, connection))
                {
                    myCommand.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public static void DeleteReader(int Id)
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true";
                connection.Open();
                string sql = "Delete from reader where reader.Id = " + Id.ToString();
                using (SqlCommand myCommand = new SqlCommand(sql, connection))
                {
                    myCommand.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public static void DeleteAuthor(int Id)
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true";
                connection.Open();
                string sql = "Delete from author where author.Id = " + Id.ToString();
                using (SqlCommand myCommand = new SqlCommand(sql, connection))
                {
                    myCommand.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public static void DeleteLog(int Id)
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true";
                connection.Open();
                string sql = "Delete from log where log.Id = " + Id.ToString();
                using (SqlCommand myCommand = new SqlCommand(sql, connection))
                {
                    myCommand.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
#endregion
    }
}
