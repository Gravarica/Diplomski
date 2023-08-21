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
    }
}
