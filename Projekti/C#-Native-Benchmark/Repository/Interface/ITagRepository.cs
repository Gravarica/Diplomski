
using Native.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Repository.Interface
{
    public interface ITagRepository
    {
        List<TagCount> GetTagsOnFiveOrMorePosts();

        List<UserTag> GetTagCountPerUser();

        List<string> GetTagsForUser(string email);
    }
}
