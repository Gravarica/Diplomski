from sqlalchemy import Column, Integer, String, Date, DateTime, ForeignKey, Table
from sqlalchemy.orm import relationship
from sqlalchemy.ext.declarative import declarative_base
from connection.connectivity import Base


class Tag(Base):
    __tablename__ = 'Tags'
    tag_id = Column(Integer, primary_key=True)
    tag_name = Column(String(50))
