using EntityFramework_Benchmark.Repository.IRepository;
using EntityFramework_Benchmark.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Benchmark.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        public BenchmarkDbContext Context { get; set; }

        public ProfileRepository() 
        {
            Context = new BenchmarkDbContext();
        }

        public ProfileRepository(BenchmarkDbContext context) 
        {
            Context = context;
        }
    }
}
