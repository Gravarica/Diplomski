import time


class Stopwatch:
    def __init__(self):
        self.start_time = None
        self.end_time = None

    def start(self):
        self.start_time = time.time()

    def stop(self):
        self.end_time = time.time()

    def get_time(self):
        if self.start_time is None or self.end_time is None:
            raise Exception("Must call start() and stop() before get_time()")
        return self.end_time - self.start_time

    def get_milliseconds(self):
        if self.start_time is None or self.end_time is None:
            raise Exception("Must call start() and stop() before get_time()")
        return round((self.end_time - self.start_time)*1000)
