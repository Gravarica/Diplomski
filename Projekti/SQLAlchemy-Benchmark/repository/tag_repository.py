from model.tag import Tag
from model.user import User
from model.tag import Tag
from model.post import Post, post_tags_table
from sqlalchemy import func, text


class TagRepository:

    def __init__(self, session):
        self.session = session

    def get_tags_by_user(self, email):
        return self.session.query(Tag.tag_name)\
            .distinct()\
            .join(post_tags_table, Tag.tag_id == post_tags_table.c.tag_id)\
            .join(Post, Post.post_id == post_tags_table.c.post_id)\
            .join(User, User.user_id == Post.user_id)\
            .filter(User.email == email).all()

    def count_posts_per_tag(self):
        return self.session.query(Tag.tag_name, func.count(Post.post_id).label('total_posts'))\
            .join(post_tags_table, Tag.tag_id == post_tags_table.c.tag_id)\
            .join(Post, Post.post_id == post_tags_table.c.post_id)\
            .group_by(Tag.tag_name)\
            .having(text('total_posts >= 5')).all()

    def count_tags_per_user(self):
        query = self.session.query(Post.user_id, func.count(post_tags_table.c.tag_id)
                                   .label('total_tags'))\
            .join(post_tags_table, Post.post_id == post_tags_table.c.post_id)\
            .group_by(Post.user_id)
        print(query)
        return query.all()
