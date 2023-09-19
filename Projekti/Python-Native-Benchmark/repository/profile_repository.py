class ProfileRepository:
    def __init__(self, conn):
        self.conn = conn

    def delete_profiles_by_phone_number(self, number):

        query = "DELETE FROM Profiles WHERE Profiles.phone_number LIKE %s"

        with self.conn.cursor() as cursor: 
            cursor.execute(query, (number + "%",))

        self.conn.commit()