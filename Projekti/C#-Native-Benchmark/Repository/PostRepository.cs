using MySql.Data.MySqlClient;
using Native.Repository.Interface;
using Native.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly string _connectionString;

        public PostRepository(IDatabaseConnection connection)
        {
            _connectionString = connection.ConnectionString;
        }

        public void UpdateUserPosts(int userId, string text)
        {
            MySqlConnection connection = new(_connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "UPDATE Posts SET content = @text WHERE user_id = @id";
            command.Parameters.AddWithValue("@id", userId);
            command.Parameters.AddWithValue("@text", text);

            command.ExecuteNonQuery();
        }
    }
}
