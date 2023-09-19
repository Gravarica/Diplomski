class PostRepository:
    def __init__(self, conn):
        self.conn = conn

    def update_posts_for_user(self, user_id, content):

        query = "UPDATE Posts SET content = %s WHERE user_id = %s"
        

        with self.conn.cursor() as cursor: 
            cursor.execute(query, (content, user_id,))

        self.conn.commit()