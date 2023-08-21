using Native.Model;
using Native.Repository.Interface;
using Native.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Native.Benchmark
{
    public class Benchmark
    {
        private readonly IUserRepository    userRepository;
        private readonly IPostRepository    postRepository;
        private readonly ITagRepository     tagRepository;
        private readonly IProfileRepository profileRepository;

        public Benchmark(
            IUserRepository userRepository,
            IPostRepository postRepository,
            ITagRepository tagRepository,
            IProfileRepository profileRepository)
        {
            this.userRepository = userRepository;
            this.postRepository = postRepository;
            this.tagRepository = tagRepository;
            this.profileRepository = profileRepository;
        }

        

        public void RunAll()
        {
            ExecuteFirstReadQuery();
            ExecuteSecondReadQuery();
        }

        /// <summary>
        /// SELECT * FROM Users WHERE date_of_birth >= @date
        /// </summary>
        public void ExecuteFirstReadQuery()
        {
            string query = "SELECT * FROM Users WHERE date_of_birth >= @date";
            ResultWriter.WriteHeader(query);

            BStopwatch.Start();

            var users = userRepository?.GetUsersBornAfter(new DateTime(2000, 12, 31));

            BStopwatch.Stop();

            ResultWriter.WriteFooter(users.Count);
        }

        /// <summary>
        /// SELECT u.user_id, u.email, COUNT(p.post_id) 
        /// FROM Users AS u "
        /// LEFT OUTER JOIN Posts AS p ON u.user_id = p.user_id "
        /// GROUP BY u.user_id"
        /// </summary>
        public void ExecuteSecondReadQuery()
        {
            string query = "SELECT u.user_id, u.email, COUNT(p.post_id) \n" +
                           "FROM Users AS u \n" +
                           "LEFT OUTER JOIN Posts AS p ON u.user_id = p.user_id \n" +
                           "GROUP BY u.user_id\n";
            ResultWriter.WriteHeader(query);

            BStopwatch.Start();

            var users = userRepository?.GetNumberOfPostsForEachUser();

            BStopwatch.Stop();

            ResultWriter.WriteFooter(users.Count);
        }
    }
}
