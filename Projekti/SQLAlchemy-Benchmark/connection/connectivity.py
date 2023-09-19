from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker
from sqlalchemy.ext.declarative import declarative_base
import logging

# db_log_file_name = 'sqlalchemy.log'
# db_handler_log_level = logging.INFO
# db_logger_log_level = logging.DEBUG

# db_handler = logging.FileHandler(db_log_file_name)
# db_handler.setLevel(db_handler_log_level)

# db_logger = logging.getLogger('sqlalchemy')
# db_logger.addHandler(db_handler)
# db_logger.setLevel(db_logger_log_level)

engine = create_engine(
    'mysql+pymysql://root:root@localhost:3308/diplomski', echo=False)
Session = sessionmaker(bind=engine)
Base = declarative_base()


def get_session():
    session = Session()
    return session
