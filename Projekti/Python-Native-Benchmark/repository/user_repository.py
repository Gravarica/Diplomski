from model.user import User
from mysql.connector.connection import MySQLConnection

class UserRepository:
    def __init__(self, conn : MySQLConnection):
        self.conn = conn

    def fetch_all_users(self):
        with self.conn.cursor() as cursor:
            cursor.execute("SELECT * FROM users")
            return cursor.fetchall()

    def fetch_user_by_id(self, user_id):
        with self.conn.cursor() as cursor:
            cursor.execute("SELECT * FROM users WHERE id = %s", (user_id,))
            return cursor.fetchone()

    def add_user(self, first_name, last_name, email, date):
        with self.conn.cursor() as cursor:
            cursor.execute(
                "INSERT INTO Users (first_name, last_name, email, date_of_birth) VALUES (%s, %s, %s, %s)",
                (first_name, last_name, email, date)
            )
            self.conn.commit()
            return cursor.lastrowid 
        
    def get_users_born_after(self, year):

        query = "SELECT * FROM Users WHERE date_of_birth >= (%s)"
        users = [];
        params = [];
        params.append(year)

        with self.conn.cursor(buffered=True) as cursor:
            cursor.execute(query, params)

        for (user_id, first_name, last_name, email, date_of_birth) in cursor:
            users.append(User(user_id, first_name, last_name, email, date_of_birth))

        return users

    def get_number_of_posts_for_each_user(self):

        query =  "SELECT u.user_id, u.email, COUNT(p.post_id) "
        query += "FROM Users AS u "
        query += "LEFT OUTER JOIN Posts AS p ON u.user_id = p.user_id "
        query += "GROUP BY u.user_id"

        users = []

        with self.conn.cursor(buffered=True) as cursor:
            cursor.execute(query)

        for (user_id, email, count) in cursor:
            users.append(tuple((user_id, email, count)))

        return users
    
    def get_top_five_users(self):

        query =  "SELECT u.user_id, u.email, COUNT(p.post_id) " 
        query += "FROM Users AS u " 
        query += "LEFT OUTER JOIN Posts AS p ON u.user_id = p.user_id " 
        query +=  "GROUP BY u.user_id"

        users = []

        with self.conn.cursor(buffered=True) as cursor: 
            cursor.execute(query)

        for (user_id, email, count) in cursor:
            users.append(tuple((user_id, email, count)))

        return users
    
    def get_users_by_keyword(self, keyword):

        query =  "SELECT u.user_id, u.email, p.bio "
        query += "FROM Users u, Profiles p "
        query += "WHERE u.user_id = p.user_id "
        query += "AND p.bio LIKE (%s)"

        users = [] 
        params = []
        params.append(keyword + "%")

        with self.conn.cursor(buffered=True) as cursor:
            cursor.execute(query, params)

        for (user_id, email, bio) in cursor: 
            users.append(tuple((user_id, email, bio)))

        return users

        
