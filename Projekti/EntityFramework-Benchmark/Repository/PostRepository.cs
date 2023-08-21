using EntityFramework_Benchmark.Repository.IRepository;
using EntityFramework_Benchmark.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Benchmark.Repository
{
    public class PostRepository : IPostRepository
    {

        public BenchmarkDbContext Context { get; set; }

        public PostRepository()
        {
            Context = new BenchmarkDbContext();    
        }

        public PostRepository(BenchmarkDbContext context)
        {
            Context = context;
        }



    }
}
