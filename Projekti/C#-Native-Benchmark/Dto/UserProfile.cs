using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Dto
{
    public class UserProfile
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Bio { get; set; }

        public UserProfile() { }

        public UserProfile(int id, string email, string bio)
        {
            Id = id;
            Email = email;
            Bio = bio;
        }
    }
}
