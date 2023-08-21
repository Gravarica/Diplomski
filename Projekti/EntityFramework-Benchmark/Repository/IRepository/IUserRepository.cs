using EntityFramework_Benchmark.Dto;
using EntityFramework_Benchmark.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Benchmark.Repository.IRepository
{
    public interface IUserRepository
    {
        List<User> GetUsersBornAfter(DateTime year);

        List<UserPostCount> GetNumberOfPostsForEachUser();
    }
}
