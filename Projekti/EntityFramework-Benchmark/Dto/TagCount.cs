using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Benchmark.Dto
{
    public class TagCount
    {
        public string Name { get; set; }
        public int Count { get; set; }

        public TagCount() { }

        public TagCount(string name, int count) 
        {
            Name = name;
            Count = count;
        }

    }
}
