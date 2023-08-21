using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Benchmark.Dto
{
    public class UserPostCount
    {
        public int? Id { get; set; }

        public string? Email { get; set; }

        public int? Count { get; set; }

        public UserPostCount() { }  

        public UserPostCount(int id, string email, int count) 
        {
            Id = id;
            Email = email;
            Count = count;
        }
    }
}
