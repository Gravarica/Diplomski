from model.post import Post
from util.stopwatch import Stopwatch


class PostRepository:

    def __init__(self, session):
        self.session = session
