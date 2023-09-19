using EntityFramework_Benchmark.Dto;
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
    public class TagRepository : ITagRepository
    {
        public BenchmarkDbContext Context { get; set; }

        public TagRepository() 
        {
            Context = new BenchmarkDbContext();
        }

        public TagRepository(BenchmarkDbContext context)
        {
            Context = context;
        }

        public List<TagCount> GetTagsOnFiveOrMorePosts()
        {
            return Context.Tags
                .Include(t => t.Posts)
                .Where(t => t.Posts.Count() >= 5)
                .Select(t => new TagCount { Name = t.TagName, Count =  t.Posts.Count() })
                .ToList();
        }

        public List<UserTag> GetTagCountPerUser()
        {
            var users = Context.Posts
                        .GroupBy(p => p.UserId)
                        .Select(g => new UserTag
                        {
                            Id = g.Key,
                            Count = g.Sum(p => p.Tags.Count())
                        })
                        .ToList();

            return users;
        }

        public List<string> GetTagsForUser(string email)
        {
            return Context.Users
                .Where(u => u.Email == email)
                .Include(x => x.Posts)
                .ThenInclude(x => x.Tags)
                .SelectMany(x => x.Posts)
                .SelectMany(x => x.Tags)
                .Select(x => x.TagName)
                .Distinct()
                .ToList();
        }
    }
}
