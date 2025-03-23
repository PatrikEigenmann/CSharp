using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Bidder
{
    public class Niche
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;

        // Fetch by ID
        public static Niche FetchById(int id)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM niche WHERE id = @Id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Niche
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Comments = reader.GetString(2),
                                Subject = reader.GetString(3)
                            };
                        }
                    }
                }
            }
            return null;
        }

        // Fetch all
        public static List<Niche> FetchAll()
        {
            var niches = new List<Niche>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM niche";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            niches.Add(new Niche
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Comments = reader.GetString(2),
                                Subject = reader.GetString(3)
                            });
                        }
                    }
                }
            }
            return niches;
        }

        // Insert
        public void Insert()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO niche (name, comments, subject) VALUES (@Name, @Comments, @Subject)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@Comments", Comments);
                    cmd.Parameters.AddWithValue("@Subject", Subject);
                    cmd.ExecuteNonQuery();
                    Id = (int)conn.LastInsertRowId;
                }
            }
        }

        // Update
        public void Update()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE niche SET name = @Name, comments = @Comments, subject = @Subject WHERE id = @Id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@Comments", Comments);
                    cmd.Parameters.AddWithValue("@Subject", Subject);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}