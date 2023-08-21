from model.profile import Profile
from util.stopwatch import Stopwatch


class ProfileRepository:

    def __init__(self, session):
        self.session = session
