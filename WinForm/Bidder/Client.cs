using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Bidder
{
    public class Client
    {
        public int Id { get; set; }
        public int Niche { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Salutation { get; set; } = string.Empty;
        public string Business { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public bool EmailSent { get; set; } = false;
        public DateTime EmailDate { get; set; } = DateTime.Now;

        // Fetch by ID
        public static Client FetchById(int id)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM client WHERE id = @Id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Client
                            {
                                Id = reader.GetInt32(0),
                                Niche = reader.GetInt32(1),
                                Email = reader.GetString(2),
                                Salutation = reader.GetString(3),
                                Business = reader.GetString(4),
                                Address = reader.GetString(5),
                                Comments = reader.GetString(6),
                                Subject = reader.GetString(7),
                                EmailSent = reader.GetBoolean(8),
                                EmailDate = reader.GetDateTime(9)
                            };
                        }
                    }
                }
            }
            return null;
        }

        // Fetch all
        public static List<Client> FetchAll()
        {
            var clients = new List<Client>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM client";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clients.Add(new Client
                            {
                                Id = reader.GetInt32(0),
                                Niche = reader.GetInt32(1),
                                Email = reader.GetString(2),
                                Salutation = reader.GetString(3),
                                Business = reader.GetString(4),
                                Address = reader.GetString(5),
                                Comments = reader.GetString(6),
                                Subject = reader.GetString(7),
                                EmailSent = reader.GetBoolean(8),
                                EmailDate = reader.GetDateTime(9)
                            });
                        }
                    }
                }
            }
            return clients;
        }

        // Insert
        public void Insert()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO client (niche, email, salutation, business, address, comments, subject, email_sent, email_date) " +
                               "VALUES (@Niche, @Email, @Salutation, @Business, @Address, @Comments, @Subject, @EmailSent, @EmailDate)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Niche", Niche);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Salutation", Salutation);
                    cmd.Parameters.AddWithValue("@Business", Business);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Parameters.AddWithValue("@Comments", Comments);
                    cmd.Parameters.AddWithValue("@Subject", Subject);
                    cmd.Parameters.AddWithValue("@EmailSent", EmailSent);
                    cmd.Parameters.AddWithValue("@EmailDate", EmailDate);
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
                string query = "UPDATE client SET niche = @Niche, email = @Email, salutation = @Salutation, business = @Business, " +
                               "address = @Address, comments = @Comments, subject = @Subject, email_sent = @EmailSent, email_date = @EmailDate WHERE id = @Id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Niche", Niche);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Salutation", Salutation);
                    cmd.Parameters.AddWithValue("@Business", Business);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Parameters.AddWithValue("@Comments", Comments);
                    cmd.Parameters.AddWithValue("@Subject", Subject);
                    cmd.Parameters.AddWithValue("@EmailSent", EmailSent);
                    cmd.Parameters.AddWithValue("@EmailDate", EmailDate);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
