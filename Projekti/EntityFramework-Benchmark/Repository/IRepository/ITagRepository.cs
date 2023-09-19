using EntityFramework_Benchmark.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Benchmark.Repository.IRepository
{
    public interface ITagRepository
    {
        List<TagCount> GetTagsOnFiveOrMorePosts();

        List<UserTag> GetTagCountPerUser();

        List<string> GetTagsForUser(string email);
    }
}
