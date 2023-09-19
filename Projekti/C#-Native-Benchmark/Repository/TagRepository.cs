using MySql.Data.MySqlClient;
using Native.Dto;
using Native.Repository.Interface;
using Native.Settings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly string _connectionString;

        public TagRepository(IDatabaseConnection connection)
        {
            _connectionString = connection.ConnectionString;
        }

        public List<string> GetTagsForUser(string email)
        {
            List<string> tags = new List<string>();
            using MySqlConnection connection = new(_connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT DISTINCT t.tag_name " +
                                  "FROM Users AS u, Posts AS p, Tags AS t, Post_Tags AS pt " +
                                  "WHERE u.user_id = p.user_id AND p.post_id = pt.post_id AND t.tag_id = pt.tag_id " +
                                  "AND u.email = @email";
            command.Parameters.AddWithValue("@email", email);

            using MySqlDataReader reader= command.ExecuteReader();

            while(reader.Read())
            {
                tags.Add(reader.GetString(0)); 
            }

            return tags;
        }

        public List<TagCount> GetTagsOnFiveOrMorePosts()
        {
            List<TagCount> tags = new List<TagCount>();
            using MySqlConnection connection = new(_connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT t.tag_name, COUNT(p.post_id) as total_posts " +
                "FROM Posts as p, Tags as t, Post_Tags as pt " +
                "WHERE p.post_id = pt.post_id AND t.tag_id = pt.tag_id " +
                "GROUP BY t.tag_name " +
                "HAVING total_posts >= 5";

            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                tags.Add(new TagCount(reader.GetString(0), reader.GetInt32(1)));
            }

            return tags;
        }

        public List<UserTag> GetTagCountPerUser()
        {
            List<UserTag> tags = new List<UserTag>();
            using MySqlConnection connection = new(_connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT p.user_id, COUNT(pt.tag_id) as total_tags " +
                "FROM Posts as p, Tags as t, Post_Tags as pt " +
                "WHERE p.post_id = pt.post_id " +
                "GROUP BY p.user_id";

            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                tags.Add(new UserTag(reader.GetInt32(0), reader.GetInt32(1)));
            }

            return tags;
        }
    }
}
