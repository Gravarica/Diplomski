class Post: 

    def __init__(self, id, user_id, title, content, timestamp):
        self.post_id = id
        self.user_id = user_id
        self.title = title
        self.content = content 
        self.timestamp = timestamp 
        self.tags = []

    def add_tags(self, tags):
        self.tags = tags

    def add_tag(self, tag):
        self.tags.append(tag)
        