class TagRepository:
    def __init__(self, conn):
        self.conn = conn

    def get_tags_by_user(self, email):
        
        query =  "SELECT DISTINCT t.tag_name " 
        query += "FROM Users AS u, Posts AS p, Tags AS t, Post_Tags AS pt "
        query += "WHERE u.user_id = p.user_id AND p.post_id = pt.post_id AND t.tag_id = pt.tag_id "
        query += "AND u.email = %s"

        tags = [] 
        params = [] 
        params.append(email)

        with self.conn.cursor(buffered=True) as cursor:
            cursor.execute(query, (email,))

        for (tag_name) in cursor: 
            tags.append(tag_name)

        return tags
    
    def count_posts_per_tag(self):

        query =  "SELECT t.tag_name, COUNT(p.post_id) as total_posts "
        query += "FROM Posts as p, Tags as t, Post_Tags as pt "
        query += "WHERE p.post_id = pt.post_id AND t.tag_id = pt.tag_id "
        query += "GROUP BY t.tag_name "
        query += "HAVING total_posts >= 5"

        tag_posts = []

        with self.conn.cursor(buffered=True) as cursor: 
            cursor.execute(query)

        for (tag_name, count) in cursor: 
            tag_posts.append(tuple((tag_name, count)))

        return tag_posts
    
    def count_tags_per_user(self):
        query =  "SELECT p.user_id, COUNT(pt.tag_id) as total_tags "
        query += "FROM Posts as p, Post_Tags as pt "
        query += "WHERE p.post_id = pt.post_id "
        query += "GROUP BY p.user_id"

        tags_users = []

        with self.conn.cursor(buffered=True) as cursor:
            cursor.execute(query)

        for (user_id, count) in cursor: 
            tags_users.append(tuple((user_id, count)))

        return tags_users