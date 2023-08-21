CREATE TABLE Users (
    user_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    email VARCHAR(100),
    date_of_birth DATE
);

INSERT INTO Users (user_id, first_name, last_name, email, date_of_birth)
VALUES (1, 'John', 'Doe', 'john.doe@example.com', '1980-01-01');

CREATE TABLE Profiles (
    profile_id INT PRIMARY KEY,
    user_id INT,
    address VARCHAR(200),
    phone_number VARCHAR(15),
    bio VARCHAR(500),
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

INSERT INTO Profiles (profile_id, user_id, address, phone_number, bio)
VALUES (1, 1, '123 Main St', '555-555-5555', 'Hello, I am John Doe');

CREATE TABLE Posts (
    post_id INT PRIMARY KEY,
    user_id INT,
    title VARCHAR(100),
    content TEXT,
    timestamp TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

INSERT INTO Posts (post_id, user_id, title, content, timestamp)
VALUES (1, 1, 'My First Post', 'This is my first post.', NOW());

CREATE TABLE Tags (
    tag_id INT PRIMARY KEY,
    tag_name VARCHAR(50)
);

CREATE TABLE Post_Tags (
    post_id INT,
    tag_id INT,
    PRIMARY KEY (post_id, tag_id),
    FOREIGN KEY (post_id) REFERENCES Posts(post_id),
    FOREIGN KEY (tag_id) REFERENCES Tags(tag_id)
);

CREATE TABLE Post_Tags (
    post_id INT,
    tag_id INT,
    PRIMARY KEY (post_id, tag_id),
    FOREIGN KEY (post_id) REFERENCES Posts(post_id),
    FOREIGN KEY (tag_id) REFERENCES Tags(tag_id)
);

INSERT INTO Post_Tags (post_id, tag_id)
VALUES (1, 1);

DELIMITER $$

CREATE PROCEDURE InsertRandomUsers(IN NumRows INT)
BEGIN
    DECLARE i INT;
    SET i = 1;
    START TRANSACTION;
    WHILE i <= NumRows DO
        INSERT INTO Users (user_id, first_name, last_name, email, date_of_birth)
        VALUES (
            i,
            CONCAT('FirstName', i),
            CONCAT('LastName', i),
            CONCAT('user', i, '@example.com'),
            DATE_ADD('1980-01-01', INTERVAL FLOOR(0 + (RAND() * 15705)) DAY)  -- random date between 1980 and 2023
        );
        SET i = i + 1;
    END WHILE;
    COMMIT;
END$$

DELIMITER ;

CALL InsertRandomUsers(20000);

DELIMITER $$

CREATE PROCEDURE InsertRandomProfiles(IN NumRows INT)
BEGIN
    DECLARE i INT;
    SET i = 1;
    START TRANSACTION;
    WHILE i <= NumRows DO
        INSERT INTO Profiles (profile_id, user_id, address, phone_number, bio)
        VALUES (
            i,
            i,
            CONCAT('Address', i),
            CONCAT('555-', LPAD(i, 4, '0')),
            CONCAT('This is a bio for user ', i)
        );
        SET i = i + 1;
    END WHILE;
    COMMIT;
END$$

DELIMITER ;

CALL InsertRandomProfiles(20000);

DELIMITER $$

CREATE PROCEDURE InsertRandomPosts(IN NumRows INT)
BEGIN
    DECLARE i INT;
    SET i = 1;
    START TRANSACTION;
    WHILE i <= NumRows DO
        INSERT INTO Posts (post_id, user_id, title, content, timestamp)
        VALUES (
            i,
            CEIL(RAND() * NumRows),
            CONCAT('Title ', i),
            CONCAT('This is post number ', i),
            NOW()
        );
        SET i = i + 1;
    END WHILE;
    COMMIT;
END$$

DELIMITER ;

CALL InsertRandomPosts(20000);


DELIMITER $$

CREATE PROCEDURE InsertRandomTags(IN NumRows INT)
BEGIN
    DECLARE i INT;
    SET i = 1;
    START TRANSACTION;
    WHILE i <= NumRows DO
        INSERT INTO Tags (tag_id, tag_name)
        VALUES (
            i,
            CONCAT('tag', i)
        );
        SET i = i + 1;
    END WHILE;
    COMMIT;
END$$

DELIMITER ;


CALL InsertRandomTags(20000);


DELIMITER $$

CREATE PROCEDURE InsertRandomPostTags(IN NumRows INT)
BEGIN
    DECLARE i INT;
    SET i = 1;
    START TRANSACTION;
    WHILE i <= NumRows DO
        INSERT INTO Post_Tags (post_id, tag_id)
        VALUES (
            CEIL(RAND() * NumRows),
            CEIL(RAND() * NumRows)
        );
        SET i = i + 1;
    END WHILE;
    COMMIT;
END$$

DELIMITER ;


CALL InsertRandomPostTags(20000);






