
from util.stopwatch import Stopwatch
from model.user import User
from connection.connectivity import get_session
from util.result_writer import print_footer, print_header
from benchmark.benchmark import Benchmark

session = get_session()

benchmark = Benchmark(session)

benchmark.execute_second_query()
