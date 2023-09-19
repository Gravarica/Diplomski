from benchmark.benchmark import Benchmark
from config.database import Database
from config.config import DB_CONFIG

db = Database(DB_CONFIG)
connection = db.connect()

benchmark = Benchmark(connection)

benchmark.run_all(100)