using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Dto
{
    public class UserTag
    {

        public int Id { get; set; }

        public int Count { get; set; }

        public UserTag() { }

        public UserTag(int id, int count)
        {
            Id = id;
            Count = count;
        }
    }
}
