from sqlalchemy import Column, Integer, String, Date, DateTime, ForeignKey, Table
from sqlalchemy.orm import relationship
from sqlalchemy.ext.declarative import declarative_base
from connection.connectivity import Base


class Profile(Base):
    __tablename__ = 'Profiles'
    profile_id = Column(Integer, primary_key=True)
    user_id = Column(Integer, ForeignKey('Users.user_id'))
    address = Column(String(255))
    phone_number = Column(String(20))
    bio = Column(String(255))
