from util.stopwatch import Stopwatch
from util.result_writer import print_footer, print_header
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

    def run_all(self):
        self.execute_first_query()

    def execute_first_query(self):

        print_header("Get users born after given year.")

        year = datetime.date(2000, 1, 1)

        self.stopwatch.start()

        users = self.user_repository.get_users_born_after(year)

        self.stopwatch.stop()

        print_footer(len(users), self.stopwatch.get_milliseconds())

    def execute_second_query(self):

        print_header("Get number of posts for each user.")

        self.stopwatch.start()

        result = self.user_repository.get_number_of_posts_for_each_user()

        self.stopwatch.stop()

        print_footer(len(result), self.stopwatch.get_milliseconds())
