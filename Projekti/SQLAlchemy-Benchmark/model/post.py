from sqlalchemy import Column, Integer, String, Date, DateTime, ForeignKey, Table
from sqlalchemy.orm import relationship
from sqlalchemy.ext.declarative import declarative_base
from connection.connectivity import Base
from model.tag import Tag

post_tags_table = Table('Post_Tags', Base.metadata,
                        Column('post_id', Integer,
                               ForeignKey('Posts.post_id')),
                        Column('tag_id', Integer, ForeignKey('Tags.tag_id'))
                        )


class Post(Base):
    __tablename__ = 'Posts'
    post_id = Column(Integer, primary_key=True)
    user_id = Column(Integer, ForeignKey('Users.user_id'))
    title = Column(String(255))
    content = Column(String)
    timestamp = Column(DateTime)
    tags = relationship('Tag', secondary=post_tags_table, backref='posts')
