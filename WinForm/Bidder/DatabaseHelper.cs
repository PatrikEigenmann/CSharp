using System.Data.SQLite;

namespace Bidder
{
    public static class DatabaseHelper
    {
        private static string _connectionString = "Data Source=mydb.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }
    }
}