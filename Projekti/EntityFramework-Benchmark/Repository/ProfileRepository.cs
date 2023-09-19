using EntityFramework_Benchmark.Repository.IRepository;
using EntityFramework_Benchmark.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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

        public void DeleteProfilesWithPhoneNumber(string phoneNumber)
        {
            var transaction = Context.Database.BeginTransaction();
            var profilesToDelete = Context.Profiles
                                    .Where(p => p.PhoneNumber.Contains(phoneNumber))
                                    .ToList();
            Context.Profiles.RemoveRange(profilesToDelete);
            Context.SaveChanges();
            transaction.Rollback();
        }
    }
}
