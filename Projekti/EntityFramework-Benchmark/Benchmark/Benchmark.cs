using EntityFramework_Benchmark.Repository.IRepository;
using EntityFramework_Benchmark.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Benchmark.Benchmark
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
        /// Get users born after given year.
        /// </summary>
        public void ExecuteFirstReadQuery()
        {
            ResultWriter.WriteHeader("Get users born after given year.");

            BStopwatch.Start();

            var users = userRepository?.GetUsersBornAfter(new DateTime(2000, 12, 31));

            BStopwatch.Stop();

            ResultWriter.WriteFooter(users.Count);
        }

        /// <summary>
        /// Get number of posts for each user.
        /// </summary>
        public void ExecuteSecondReadQuery()
        {
            ResultWriter.WriteHeader("Get number of posts for each user.");

            BStopwatch.Start();

            var users = userRepository?.GetNumberOfPostsForEachUser();

            BStopwatch.Stop();

            ResultWriter.WriteFooter(users.Count);
        }
    }
}
