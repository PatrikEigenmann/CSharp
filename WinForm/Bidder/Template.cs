using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Bidder
{
    public class Template
    {
        public int Id { get; set; }
        public int Niche { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;

        // Fetch by ID
        public static Template FetchById(int id)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM template WHERE id = @Id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Template
                            {
                                Id = reader.GetInt32(0),
                                Niche = reader.GetInt32(1),
                                Text = reader.GetString(2),
                                Comments = reader.GetString(3),
                                Subject = reader.GetString(4)
                            };
                        }
                    }
                }
            }
            return null;
        }

        // Fetch all
        public static List<Template> FetchAll()
        {
            var templates = new List<Template>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM template";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            templates.Add(new Template
                            {
                                Id = reader.GetInt32(0),
                                Niche = reader.GetInt32(1),
                                Text = reader.GetString(2),
                                Comments = reader.GetString(3),
                                Subject = reader.GetString(4)
                            });
                        }
                    }
                }
            }
            return templates;
        }

        // Insert
        public void Insert()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO template (niche, text, comments, subject) VALUES (@Niche, @Text, @Comments, @Subject)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Niche", Niche);
                    cmd.Parameters.AddWithValue("@Text", Text);
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
                string query = "UPDATE template SET niche = @Niche, text = @Text, comments = @Comments, subject = @Subject WHERE id = @Id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Niche", Niche);
                    cmd.Parameters.AddWithValue("@Text", Text);
                    cmd.Parameters.AddWithValue("@Comments", Comments);
                    cmd.Parameters.AddWithValue("@Subject", Subject);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
