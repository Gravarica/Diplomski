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
    public class ProfileRepository : IProfileRepository
    {
        private readonly string _connectionString;

        public ProfileRepository(IDatabaseConnection connection)
        {
            _connectionString = connection.ConnectionString;
        }

        public void DeleteProfilesWithPhoneNumber(string phoneNumber)
        {
            using MySqlConnection connection = new(_connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "DELETE FROM Profiles WHERE Profiles.phone_number LIKE @param";
            command.Parameters.AddWithValue("@param", phoneNumber + "%");
            command.ExecuteNonQuery();
        }
    }
}
