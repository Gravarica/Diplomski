using EntityFramework_Benchmark.Dto;
using EntityFramework_Benchmark.Model;
using EntityFramework_Benchmark.Repository.IRepository;
using EntityFramework_Benchmark.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Benchmark.Repository
{
    public class UserRepository : IUserRepository
    {
        public BenchmarkDbContext Context { get; set; }

        public UserRepository() 
        {
            Context = new BenchmarkDbContext();
        }

        public UserRepository(BenchmarkDbContext context) 
        {
            Context = context;
        }

        public List<User> GetUsersBornAfter(DateTime year)
        {
            return Context.Users.Where(x => x.DateOfBirth >= year).ToList();
        }

        public List<UserPostCount> GetNumberOfPostsForEachUser()
        {
            return Context.Users.Include(x => x.Posts).Select(x => new UserPostCount { Id = x.UserId, Email = x.Email, Count = x.Posts.Count }).ToList();
        }
    }
}
