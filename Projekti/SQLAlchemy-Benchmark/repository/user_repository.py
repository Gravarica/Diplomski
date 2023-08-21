from model.user import User
from util.stopwatch import Stopwatch
from sqlalchemy import func
from model.post import Post


class UserRepository:

    def __init__(self, session):
        self.session = session

    def get_users_born_after(self, year):

        return self.session.query(User).filter(User.date_of_birth > year).all()

    def get_number_of_posts_for_each_user(self):

        return self.session.query(
            User.user_id.label('user_id'),
            User.email.label('email'),
            func.count(Post.post_id).label('Count')
        ).outerjoin(
            Post, User.user_id == Post.user_id
        ).group_by(
            User.user_id
        ).all()
