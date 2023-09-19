using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Benchmark.Repository.IRepository
{
    public interface IProfileRepository
    {
        void DeleteProfilesWithPhoneNumber(string phoneNumber);
    }
}
