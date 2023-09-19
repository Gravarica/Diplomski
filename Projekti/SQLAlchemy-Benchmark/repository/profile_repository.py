from model.profile import Profile
from util.stopwatch import Stopwatch


class ProfileRepository:

    def __init__(self, session):
        self.session = session

    def delete_profiles_by_phone_number(self, number):
        profiles_to_delete = self.session.query(Profile).filter(
            Profile.phone_number.like(number + '%')).all()
        for profile in profiles_to_delete:
            self.session.delete(profile)
        self.session.rollback()
