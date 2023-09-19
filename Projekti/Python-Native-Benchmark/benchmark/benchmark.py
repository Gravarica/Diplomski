from util.stopwatch import Stopwatch
from util.result_writer import print_footer, print_header, print_average_footer
from repository.post_repository import PostRepository
from repository.user_repository import UserRepository
from repository.tag_repository import TagRepository
from repository.profile_repository import ProfileRepository
import datetime


class Benchmark:

    def __init__(self, connection):
        self.user_repository = UserRepository(connection)
        self.post_repository = PostRepository(connection)
        self.tag_repository = TagRepository(connection)
        self.profile_repository = ProfileRepository(connection)
        self.stopwatch = Stopwatch()

    def run_all(self, times):
        # self.execute_first_query(times)
        # self.execute_second_query(times)
        # self.execute_third_query(times)
        # self.execute_fourth_query(times)
        #self.execute_fifth_query(times)
        #self.execute_sixth_query(times)
        #self.execute_seventh_query(times)
        self.execute_eigth_query(times)
        self.execute_ninth_query(times)
        self.execute_tenth_query(times)

    def execute_first_query(self, times):

        print_header("Q1")

        totalMilliseconds = 0

        year = datetime.date(2000, 1, 1)

        for i in range (1, times):

            self.stopwatch.start()

            users = self.user_repository.get_users_born_after(year)

            self.stopwatch.stop()

            totalMilliseconds += self.stopwatch.get_milliseconds()

        average = totalMilliseconds*1.0 / times
        print_average_footer(average)

    def execute_second_query(self, times):

        print_header("Q2")

        totalMilliseconds = 0

        for i in range(1, times):

            self.stopwatch.start()

            result = self.user_repository.get_number_of_posts_for_each_user()

            self.stopwatch.stop()

            totalMilliseconds += self.stopwatch.get_milliseconds()

        average = totalMilliseconds*1.0 / times
        print_average_footer(average)

    def execute_third_query(self, times):

        print_header("Q3")

        totalMilliseconds = 0

        for i in range(1, times):

            self.stopwatch.start()

            result = self.user_repository.get_top_five_users()

            self.stopwatch.stop()

            totalMilliseconds += self.stopwatch.get_milliseconds()

        average = totalMilliseconds*1.0 / times
        print_average_footer(average)

    def execute_fourth_query(self, times):

        print_header("Q4")

        totalMilliseconds = 0

        for i in range(1, times):

            self.stopwatch.start()

            result = self.user_repository.get_users_by_keyword("59")

            self.stopwatch.stop()

            totalMilliseconds += self.stopwatch.get_milliseconds()

        average = totalMilliseconds*1.0 / times
        print_average_footer(average)

    def execute_fifth_query(self, times):

        print_header("Q5")

        totalMilliseconds = 0

        for i in range(1, times):

            self.stopwatch.start()

            self.user_repository.add_user("Pera", "Petrovic", "perica@example.com", datetime.date(2000, 1, 1))

            self.stopwatch.stop()

            totalMilliseconds += self.stopwatch.get_milliseconds()

        average = totalMilliseconds*1.0 / times
        print_average_footer(average)

    def execute_sixth_query(self, times):

        print_header("Q6")

        totalMilliseconds = 0

        for i in range(1, times):

            self.stopwatch.start()

            result = self.tag_repository.count_posts_per_tag()

            self.stopwatch.stop()

            totalMilliseconds += self.stopwatch.get_milliseconds()

        average = totalMilliseconds*1.0 / times
        print_average_footer(average)

    def execute_seventh_query(self, times):

        print_header("Q7")

        totalMilliseconds = 0

        for i in range(1, times):

            self.stopwatch.start()

            result = self.tag_repository.count_tags_per_user()

            self.stopwatch.stop()

            totalMilliseconds += self.stopwatch.get_milliseconds()

        average = totalMilliseconds*1.0 / times
        print_average_footer(average)

    def execute_eigth_query(self, times):

        print_header("Q8")

        totalMilliseconds = 0

        for i in range(1, times):

            self.stopwatch.start()

            result = self.tag_repository.get_tags_by_user("user199@example.com")

            self.stopwatch.stop()

            totalMilliseconds += self.stopwatch.get_milliseconds()

        average = totalMilliseconds*1.0 / times
        print_average_footer(average)

    def execute_ninth_query(self, times):

        print_header("Q9")

        totalMilliseconds = 0

        for i in range(1, times):

            self.stopwatch.start()

            result = self.post_repository.update_posts_for_user(99, "TEXT")

            self.stopwatch.stop()

            totalMilliseconds += self.stopwatch.get_milliseconds()

        average = totalMilliseconds*1.0 / times
        print_average_footer(average)

    def execute_tenth_query(self, times):

        print_header("Q10")

        totalMilliseconds = 0

        for i in range(1, times):

            self.stopwatch.start()

            result = self.profile_repository.delete_profiles_by_phone_number("87")

            self.stopwatch.stop()

            totalMilliseconds += self.stopwatch.get_milliseconds()

        average = totalMilliseconds*1.0 / times
        print_average_footer(average)
