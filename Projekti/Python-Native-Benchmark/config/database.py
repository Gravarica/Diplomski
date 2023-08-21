from mysql.connector import connect, Error

class Database:
    def __init__(self, config):
        self.config = config
        self.conn = None

    def connect(self):
        try:
            self.conn = connect(**self.config)
            return self.conn
        except Error as e:
            print(e)
    
    def close(self):
        if self.conn:
            self.conn.close()