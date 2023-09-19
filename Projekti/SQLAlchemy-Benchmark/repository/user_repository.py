from model.user import User
from util.stopwatch import Stopwatch
from sqlalchemy.orm import lazyload, noload
from sqlalchemy import func
from model.post import Post
from model.profile import Profile
from sqlalchemy import text
import cProfile


class UserRepository:

    def __init__(self, session):
        self.session = session

    def get_users_born_after(self):

        query = self.session.query(User).filter(
            User.date_of_birth >= '1990-12-31')
        return query.all()

    def get_number_of_posts_for_each_user(self):

        return self.session.query(User.user_id, User.email, func.count(Post.post_id))\
            .outerjoin(Post, User.user_id == Post.user_id)\
            .group_by(User.user_id)\
            .all()

    def get_top_five_users(self):
        return self.session.query(User.email, func.count(Post.post_id).label('total_posts'))\
            .join(Post, User.user_id == Post.user_id)\
            .group_by(User.user_id)\
            .order_by(text('total_posts DESC'))\
            .limit(5).all()

    def get_users_by_keyword(self, keyword):
        return self.session.query(User.user_id, User.first_name)\
            .join(Profile, User.user_id == Profile.user_id)\
            .filter(Profile.bio.like('%' + keyword + '%')).all()

    def add_user(self, user):
        self.session.add(user)
        self.session.commit()
