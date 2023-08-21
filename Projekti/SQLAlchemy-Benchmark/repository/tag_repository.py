from model.tag import Tag
from util.stopwatch import Stopwatch


class TagRepository:

    def __init__(self, session):
        self.session = session
