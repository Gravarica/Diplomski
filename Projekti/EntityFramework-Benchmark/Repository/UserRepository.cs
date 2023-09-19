using EntityFramework_Benchmark.Dto;
using EntityFramework_Benchmark.Model;
using EntityFramework_Benchmark.Repository.IRepository;
using EntityFramework_Benchmark.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public List<UserPostCount> GetTopFiveUsersByPostCount()
        {
            return Context.Users
                .Include(x => x.Posts)
                .Select(u => new UserPostCount { Id = u.UserId, Email = u.Email, Count = u.Posts.Count() })
                .OrderByDescending(x => x.Count)
                .Take(5)
                .AsSingleQuery()
                .ToList();      
        }

        public List<UserProfile> GetUsersWithKeywordInBio(string keyword)
        {
            return Context.Users
                    .Include(x => x.Profiles)
                    .Where(u => u.Profiles.First().Bio.Contains(keyword))
                    .Select(u => new UserProfile(u.UserId, u.Email, u.Profiles.First().Bio))
                    .ToList();
        }

        public void InsertUser(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
        }
    }
}
