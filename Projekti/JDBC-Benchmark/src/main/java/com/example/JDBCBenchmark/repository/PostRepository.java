package com.example.JDBCBenchmark.repository;

import lombok.AllArgsConstructor;
import lombok.NoArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.PreparedStatementCreator;
import org.springframework.stereotype.Repository;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;

@Repository
@NoArgsConstructor
@AllArgsConstructor
public class PostRepository {

    @Autowired
    private JdbcTemplate jdbc;

    public void updatePostContentForUser(String content, Integer userId) {
        PreparedStatementCreator preparedStatementCreator = new PreparedStatementCreator() {
            @Override
            public PreparedStatement createPreparedStatement(Connection con) throws SQLException {
                String query = "UPDATE Posts SET content = ? WHERE user_id = ?";
                PreparedStatement ps = con.prepareStatement(query);
                ps.setString(1, content);
                ps.setInt(2, userId);
                return ps;
            }
        };

        jdbc.update(preparedStatementCreator);
    }
}
