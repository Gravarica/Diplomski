using Native.Dto;
using Native.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Repository.Interface
{
    public interface IUserRepository
    {
        List<User> GetUsersBornAfter(DateTime year);

        List<UserPostCount> GetNumberOfPostsForEachUser();

        List<UserPostCount> GetTopFiveUsersByPostCount();

        List<UserProfile> GetUsersWithKeywordInBio(string keyword);

        void InsertUser(User user);
    }
}
