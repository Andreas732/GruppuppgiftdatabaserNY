using System;
using System.Data.SqlClient;

namespace Gruppuppgiftdatabaser
{
    public class DatabaseService
    {
        private readonly string _connectionString = "Server=localhost;Database=LibraryDB;Trusted_Connection=True;";

        // Skapa en metod för att hämta en SQL-anslutning
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        // Hämta en lista med böcker
        public void ListBooks()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Books";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("\nAvailable Books:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["BookID"]}: {reader["Title"]} by {reader["Author"]}");
                        }
                    }
                }
            }
        }

        // Låna en bok
        public void BorrowBook(int userID, int bookID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "EXEC BorrowBook @UserID, @BookID";  // Din lagrade procedur
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@BookID", bookID);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Book borrowed successfully!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }
    }
}
