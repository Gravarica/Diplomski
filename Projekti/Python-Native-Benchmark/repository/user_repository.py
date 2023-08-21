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

    def create_user(self, user_data):
        with self.conn.cursor() as cursor:
            cursor.execute(
                "INSERT INTO users (username, email, password) VALUES (%s, %s, %s)",
                (user_data["username"], user_data["email"], user_data["password"])
            )
            self.conn.commit()
            return cursor.lastrowid  # Return the id of newly created user
        
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
        
