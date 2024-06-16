using Cs_pr01.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_pr01.Sql
{
    public class BoardContext
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["board"].ConnectionString;

        public List<Post> GetAllPosts()
        {
            List<Post> posts = new List<Post>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Posts", connection);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Post post = new Post
                        {
                            PostID = reader.GetInt32("PostID"),
                            Title = reader.GetString("Title"),
                            Content = reader.GetString("Content"),
                            CreatedAt = reader.GetDateTime("CreatedAt")
                        };
                        posts.Add(post);
                    }
                }
            }

            return posts;
        }

        public void AddPost(Post post)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Posts (Title, Content) VALUES (@Title, @Content)", connection);
                cmd.Parameters.AddWithValue("@Title", post.Title);
                cmd.Parameters.AddWithValue("@Content", post.Content);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
