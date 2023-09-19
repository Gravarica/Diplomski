
from util.stopwatch import Stopwatch
from model.user import User
from connection.connectivity import get_session
from util.result_writer import print_footer, print_header
from benchmark.benchmark import Benchmark
import cProfile
import pstats


session = get_session()

benchmark = Benchmark(session)

# benchmark.run_all(1)

cProfile.run('benchmark.run_all(1)')

p = pstats.Stats('thing.txt')
p.sort_stats('cumulative').print_stats(10)
