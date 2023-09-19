using EntityFramework_Benchmark.Model;
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

        public void RunAll(int times)
        {
            //ExecuteFirstQuery(times);
            //ExecuteSecondQuery(times);
            //ExecuteThirdQuery(times);
            //ExecuteFourthQuery(times);
            //ExecuteFifthQuery(times);
            //ExecuteSixthQuery(times);
            ExecuteSeventhQuery(times); 
            //ExecuteEightQuery(times);
            //ExecuteNinthQuery(times);
            //ExecuteTenthQuery(times);
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

        public void ExecuteFirstQuery(int times)
        {
            string query = "SELECT * FROM Users WHERE date_of_birth >= @date";
            ResultWriter.WriteHeader(query);
            long totalMilliseconds = 0;

            for (int i = 0; i < times; i++)
            {
                BStopwatch.Start();

                var users = userRepository?.GetUsersBornAfter(new DateTime(2000, 12, 31));

                BStopwatch.Stop();

                //ResultWriter.WriteElapsedTime(i, BStopwatch.ElapsedMilliseconds());
                totalMilliseconds += BStopwatch.ElapsedMilliseconds();
            }

            double average = totalMilliseconds / times;
            ResultWriter.WriteAverageFooter(average);
        }

        public void ExecuteSecondQuery(int times)
        {
            string query = "SELECT u.user_id, u.email, COUNT(p.post_id) \n" +
                           "FROM Users AS u \n" +
                           "LEFT OUTER JOIN Posts AS p ON u.user_id = p.user_id \n" +
                           "GROUP BY u.user_id\n";
            ResultWriter.WriteHeader(query);
            long totalMilliseconds = 0;

            for (int i = 0; i < times; i++)
            {
                BStopwatch.Start();

                var users = userRepository?.GetNumberOfPostsForEachUser();

                BStopwatch.Stop();

                //ResultWriter.WriteElapsedTime(i, BStopwatch.ElapsedMilliseconds());
                totalMilliseconds += BStopwatch.ElapsedMilliseconds();
            }

            double average = totalMilliseconds / times;
            ResultWriter.WriteAverageFooter(average);
        }

        public void ExecuteThirdQuery(int times)
        {
            string query = "Q3";
            ResultWriter.WriteHeader(query);
            long totalMilliseconds = 0;

            for (int i = 0; i < times; i++)
            {
                BStopwatch.Start();

                var values = userRepository?.GetTopFiveUsersByPostCount();

                BStopwatch.Stop();

                //ResultWriter.WriteElapsedTime(i, BStopwatch.ElapsedMilliseconds());
                totalMilliseconds += BStopwatch.ElapsedMilliseconds();
            }

            double average = totalMilliseconds / times;
            ResultWriter.WriteAverageFooter(average);
        }

        public void ExecuteFourthQuery(int times)
        {
            string query = "Q4";
            ResultWriter.WriteHeader(query);
            long totalMilliseconds = 0;

            for (int i = 0; i < times; i++)
            {
                BStopwatch.Start();

                var values = userRepository?.GetUsersWithKeywordInBio("59");

                BStopwatch.Stop();

                //ResultWriter.WriteElapsedTime(i, BStopwatch.ElapsedMilliseconds());
                totalMilliseconds += BStopwatch.ElapsedMilliseconds();
            }

            double average = totalMilliseconds / times;
            ResultWriter.WriteAverageFooter(average);
        }

        public void ExecuteFifthQuery(int times)
        {
            string query = "Q5";
            ResultWriter.WriteHeader(query);
            long totalMilliseconds = 0;

            for (int i = 0; i < times; i++)
            {
                BStopwatch.Start();

                User user = new User();
                user.Email = "djoka@gmail.com";
                user.FirstName = "Djoka";
                user.LastName = "Libo";
                user.DateOfBirth = new DateTime(2000, 12, 20);

                userRepository?.InsertUser(user);

                BStopwatch.Stop();

                //ResultWriter.WriteElapsedTime(i, BStopwatch.ElapsedMilliseconds());
                totalMilliseconds += BStopwatch.ElapsedMilliseconds();
            }

            double average = totalMilliseconds / times;
            ResultWriter.WriteAverageFooter(average);
        }

        public void ExecuteSixthQuery(int times)
        {
            string query = "Q6";
            ResultWriter.WriteHeader(query);
            long totalMilliseconds = 0;

            for (int i = 0; i < times; i++)
            {
                BStopwatch.Start();

                var values = tagRepository?.GetTagsOnFiveOrMorePosts();

                BStopwatch.Stop();

                //ResultWriter.WriteElapsedTime(i, BStopwatch.ElapsedMilliseconds());
                totalMilliseconds += BStopwatch.ElapsedMilliseconds();
            }

            double average = totalMilliseconds / times;
            ResultWriter.WriteAverageFooter(average);
        }

        public void ExecuteSeventhQuery(int times)
        {
            string query = "Q7";
            ResultWriter.WriteHeader(query);
            long totalMilliseconds = 0;

            for (int i = 0; i < times; i++)
            {
                BStopwatch.Start();

                var values = tagRepository?.GetTagCountPerUser();

                BStopwatch.Stop();

                //ResultWriter.WriteElapsedTime(i, BStopwatch.ElapsedMilliseconds());
                totalMilliseconds += BStopwatch.ElapsedMilliseconds();
            }

            double average = totalMilliseconds / times;
            ResultWriter.WriteAverageFooter(average);
        }

        public void ExecuteEightQuery(int times)
        {
            string query = "Q8";
            ResultWriter.WriteHeader(query);
            long totalMilliseconds = 0;

            for (int i = 0; i < times; i++)
            {
                BStopwatch.Start();

                var values = tagRepository?.GetTagsForUser("user199@example.com");

                BStopwatch.Stop();

                //ResultWriter.WriteElapsedTime(i, BStopwatch.ElapsedMilliseconds());
                totalMilliseconds += BStopwatch.ElapsedMilliseconds();
            }

            double average = totalMilliseconds / times;
            ResultWriter.WriteAverageFooter(average);
        }

        public void ExecuteNinthQuery(int times)
        {
            string query = "Q9";
            ResultWriter.WriteHeader(query);
            long totalMilliseconds = 0;

            for (int i = 0; i < times; i++)
            {
                BStopwatch.Start();

                postRepository?.UpdateUserPosts(99, "TEXT");

                BStopwatch.Stop();

                //ResultWriter.WriteElapsedTime(i, BStopwatch.ElapsedMilliseconds());
                totalMilliseconds += BStopwatch.ElapsedMilliseconds();
            }

            double average = totalMilliseconds / times;
            ResultWriter.WriteAverageFooter(average);
        }

        public void ExecuteTenthQuery(int times)
        {
            string query = "Q10";
            ResultWriter.WriteHeader(query);
            long totalMilliseconds = 0;

            for (int i = 0; i < times; i++)
            {
                BStopwatch.Start();

                profileRepository?.DeleteProfilesWithPhoneNumber("47");

                BStopwatch.Stop();

                //ResultWriter.WriteElapsedTime(i, BStopwatch.ElapsedMilliseconds());
                totalMilliseconds += BStopwatch.ElapsedMilliseconds();
            }

            double average = totalMilliseconds / times;
            ResultWriter.WriteAverageFooter(average);
        }
    }
}


