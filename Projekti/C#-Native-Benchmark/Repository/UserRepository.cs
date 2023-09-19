using MySql.Data.MySqlClient;
using Native.Dto;
using Native.Model;
using Native.Repository.Interface;
using Native.Settings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly string _connectionString;

        public UserRepository(IDatabaseConnection connection)
        {
            _connectionString = connection.ConnectionString;
        }

        public List<User> GetUsersBornAfter(DateTime year)
        {
            List<User> users = new List<User>();
            using MySqlConnection connection = new(_connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Users WHERE date_of_birth >= @date";
            command.Parameters.AddWithValue("@date", year);

            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                users.Add(new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4)));
            }
       
            return users;
        }

        public List<UserPostCount> GetNumberOfPostsForEachUser()
        {
            List<UserPostCount> users = new List<UserPostCount>();

            using MySqlConnection connection = new(_connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT u.user_id, u.email, COUNT(p.post_id) " +
                                  "FROM Users AS u " +
                                  "LEFT OUTER JOIN Posts AS p ON u.user_id = p.user_id " +
                                  "GROUP BY u.user_id";

            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) 
            {
                users.Add(new UserPostCount(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
            }

            return users;
        }

        public List<UserPostCount> GetTopFiveUsersByPostCount()
        {
            List<UserPostCount> users = new List<UserPostCount>();

            using MySqlConnection connection = new(_connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT u.user_id, u.email, COUNT(p.post_id) as total_posts " +
                "FROM Users as u, Posts as p " +
                "WHERE u.user_id = p.user_id " +
                "GROUP BY u.user_id " +
                "ORDER BY total_posts DESC " +
                "LIMIT 5";

            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                users.Add(new UserPostCount(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
            }

            return users;
        }

        public List<UserProfile> GetUsersWithKeywordInBio(string keyword)
        {
            List<UserProfile> users = new List<UserProfile>();

            using MySqlConnection connection = new(_connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT u.user_id, u.email, p.bio " +
                "FROM Users u, Profiles p " +
                "WHERE u.user_id = p.user_id " +
                "AND p.bio LIKE @param";

            command.Parameters.AddWithValue("@param", "%" + keyword + "%");

            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                users.Add(new UserProfile(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
            }

            return users;
        }

        public void InsertUser(User user)
        {
            using MySqlConnection connection = new(_connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            MySqlTransaction transaction = connection.BeginTransaction();

            command.CommandText = "INSERT INTO Users VALUES (@user_id, @first_name, @last_name, @email, @date_of_birth)";
            command.Parameters.AddWithValue("@first_name", user.FirstName);
            command.Parameters.AddWithValue("@last_name", user.LastName);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@date_of_birth", user.DateOfBirth);
            command.Parameters.AddWithValue("@user_id", user.UserId);

            command.ExecuteNonQuery();
            transaction.Rollback();
        }
    }
}
