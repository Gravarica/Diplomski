from model.post import Post
from util.stopwatch import Stopwatch


class PostRepository:

    def __init__(self, session):
        self.session = session

    def update_posts_for_user(self, user_id, content):
        update_posts = self.session.query(Post).filter(
            Post.user_id == user_id).update({Post.content: content})
        self.session.commit()
