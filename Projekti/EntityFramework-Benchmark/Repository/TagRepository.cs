using EntityFramework_Benchmark.Repository.IRepository;
using EntityFramework_Benchmark.Settings;
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
    }
}
