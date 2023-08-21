from sqlalchemy import Column, Integer, String, Date, DateTime, ForeignKey, Table
from sqlalchemy.orm import relationship
from connection.connectivity import Base
from model.profile import Profile
from model.post import Post


class User(Base):
    __tablename__ = 'Users'
    user_id = Column(Integer, primary_key=True)
    first_name = Column(String(50))
    last_name = Column(String(50))
    email = Column(String(50), unique=True)
    date_of_birth = Column(Date)
    posts = relationship('Post', backref='user')
    profile = relationship('Profile', uselist=False, backref='user')
