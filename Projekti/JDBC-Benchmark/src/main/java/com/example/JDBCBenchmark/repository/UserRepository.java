package com.example.JDBCBenchmark.repository;

import com.example.JDBCBenchmark.dto.UserPostCount;
import com.example.JDBCBenchmark.dto.UserProfile;
import com.example.JDBCBenchmark.mappers.UserMapper;
import com.example.JDBCBenchmark.mappers.UserPostCountMapper;
import com.example.JDBCBenchmark.mappers.UserProfileMapper;
import com.example.JDBCBenchmark.model.User;
import lombok.AllArgsConstructor;
import lombok.NoArgsConstructor;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cglib.core.Local;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.PreparedStatementCreator;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.stereotype.Repository;

import java.sql.*;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

@Repository
@RequiredArgsConstructor
public class UserRepository {

    @Autowired
    private JdbcTemplate jdbc;

    public List<User> findByDateOfBirthAfter(LocalDate year) {

        PreparedStatementCreator preparedStatementCreator = new PreparedStatementCreator() {
            @Override
            public PreparedStatement createPreparedStatement(Connection con) throws SQLException {
                String query = "SELECT * FROM Users WHERE date_of_birth > ?";
                PreparedStatement ps = con.prepareStatement(query);
                ps.setDate(1, Date.valueOf(year));
                return ps;
            }
        };

        return jdbc.query(preparedStatementCreator, new UserMapper());
    }

    public List<UserPostCount> findUsersWithPostCount() {
        String query =  "SELECT u.user_id, u.email, COUNT(p.post_id) " +
                "FROM Users AS u " +
                "LEFT OUTER JOIN Posts AS p ON u.user_id = p.user_id " +
                "GROUP BY u.user_id";

        return jdbc.query(query, new UserPostCountMapper());
    }

    public List<UserPostCount> findTopPosters() {
        String query =  "SELECT u.user_id, u.email, COUNT(p.post_id) as total_posts " +
                "FROM Users as u, Posts as p " +
                "WHERE u.user_id = p.user_id " +
                "GROUP BY u.user_id " +
                "ORDER BY total_posts DESC " +
                "LIMIT 5";

        return jdbc.query(query, new UserPostCountMapper());
    }

    public List<UserProfile> findUsersByBioKeyword(String keyword){
        PreparedStatementCreator preparedStatementCreator = new PreparedStatementCreator() {
            @Override
            public PreparedStatement createPreparedStatement(Connection con) throws SQLException {
                String query = "SELECT u.user_id, u.email, p.bio " +
                        "FROM Users u, Profiles p " +
                        "WHERE u.user_id = p.user_id " +
                        "AND p.bio LIKE ?";
                PreparedStatement ps = con.prepareStatement(query);
                ps.setString(1, "%" + keyword + "%");
                return ps;
            }
        };

        return jdbc.query(preparedStatementCreator, new UserProfileMapper());
    }

    public void addNewUser(User user) {
        PreparedStatementCreator preparedStatementCreator = new PreparedStatementCreator() {
            @Override
            public PreparedStatement createPreparedStatement(Connection con) throws SQLException {
                String query = "INSERT INTO Users (first_name, last_name, email, date_of_birth) VALUES (?,?,?,?)";
                PreparedStatement ps = con.prepareStatement(query);
                ps.setString(1, user.getFirstName());
                ps.setString(2, user.getLastName());
                ps.setString(3, user.getEmail());
                ps.setDate(4, Date.valueOf(user.getDateOfBirth()));
                return ps;
            }
        };

        jdbc.update(preparedStatementCreator);
    }

    public List<User> firstQueryNative() {
        try {
            Connection conn = DriverManager.getConnection(
                    "jdbc:mysql://localhost:3308/diplomski",
                    "root",
                    "root");
            Statement stmt = conn.createStatement();
            ResultSet rs = stmt.executeQuery("SELECT * FROM Users WHERE date_of_birth > '2000-12-31'");

            List<User> users = new ArrayList<>();
            UserMapper mapper = new UserMapper();
            while (rs.next()) {
                users.add(mapper.mapRow(rs, rs.getRow()));
            }

            return users;
        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }
}
