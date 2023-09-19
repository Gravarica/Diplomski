CREATE TABLE Users (
    user_id INT PRIMARY KEY AUTO_INCREMENT,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    email VARCHAR(100),
    date_of_birth DATE
);

CREATE TABLE Profiles (
    profile_id INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT,
    address VARCHAR(200),
    phone_number VARCHAR(15),
    bio VARCHAR(500),
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

CREATE TABLE Posts (
    post_id INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT,
    title VARCHAR(100),
    content TEXT,
    timestamp TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

CREATE TABLE Tags (
    tag_id INT PRIMARY KEY AUTO_INCREMENT,
    tag_name VARCHAR(50)
);

CREATE TABLE Post_Tags (
    post_id INT,
    tag_id INT,
    PRIMARY KEY (post_id, tag_id),
    FOREIGN KEY (post_id) REFERENCES Posts(post_id),
    FOREIGN KEY (tag_id) REFERENCES Tags(tag_id)
);

DELIMITER $$

CREATE PROCEDURE InsertRandomUsers(IN NumRows INT)
BEGIN
    DECLARE i INT;
    SET i = 1;
    START TRANSACTION;
    WHILE i <= NumRows DO
        INSERT INTO Users (first_name, last_name, email, date_of_birth)
        VALUES (
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

CALL InsertRandomUsers(100000);

DELIMITER $$

CREATE PROCEDURE InsertRandomProfiles(IN NumRows INT, IN UserNum INT)
BEGIN
    DECLARE i INT;
    SET i = 1;
    START TRANSACTION;
    WHILE i <= NumRows DO
        INSERT INTO Profiles (user_id, address, phone_number, bio)
        VALUES (
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

CALL InsertRandomProfiles(100000);

DELIMITER $$

CREATE PROCEDURE InsertRandomPosts(IN NumRows INT, IN UserNum INT)
BEGIN
    DECLARE i INT;
    SET i = 1;
    START TRANSACTION;
    WHILE i <= NumRows DO
        INSERT INTO Posts (user_id, title, content, timestamp)
        VALUES (
            i,
            FLOOR(RAND() * (UserNum - 1)) + 1,
            CONCAT('Title ', i),
            CONCAT('This is post number ', i),
            NOW()
        );
        SET i = i + 1;
    END WHILE;
    COMMIT;
END$$

DELIMITER ;

CALL InsertRandomPosts(200000);

DELIMITER $$

CREATE PROCEDURE InsertRandomTags(IN NumRows INT)
BEGIN
    DECLARE i INT;
    SET i = 1;
    START TRANSACTION;
    WHILE i <= NumRows DO
        INSERT INTO Tags (tag_name)
        VALUES (
            CONCAT('tag', i)
        );
        SET i = i + 1;
    END WHILE;
    COMMIT;
END$$

DELIMITER ;

CALL InsertRandomTags(100000);

DELIMITER $$

CREATE PROCEDURE InsertRandomPostTags(IN NumRows INT, IN PostNum INT, IN TagNum INT)
BEGIN
    DECLARE i INT DEFAULT 0;    
    START TRANSACTION;
    WHILE i <= NumRows DO
		retry: BEGIN
			DECLARE CONTINUE HANDLER FOR 1062
			BEGIN
				ITERATE retry; 
			END;
			
			INSERT INTO Post_Tags (post_id, tag_id)
			VALUES (
				CEIL(RAND() * PostNum),
				CEIL(RAND() * TagNum)
			);
        END;
        SET i = i + 1;
    END WHILE;
    COMMIT;
END$$

DELIMITER ;


CALL InsertRandomPostTags(50000);






