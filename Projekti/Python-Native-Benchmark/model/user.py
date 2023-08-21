class User:

    def __init__(self, id, first_name, last_name, email, date_of_birth):
        self.user_id = id
        self.first_name = first_name
        self.last_name = last_name
        self.email = email
        self.date_of_birth = date_of_birth
        self.posts = []
        self.profile = None
