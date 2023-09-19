package com.example.JDBCBenchmark.repository;

import lombok.NoArgsConstructor;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.PreparedStatementCreator;
import org.springframework.stereotype.Repository;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;

@Repository
@RequiredArgsConstructor
public class ProfileRepository {

    @Autowired
    private JdbcTemplate jdbc;

    public void deleteProfilesByPhonePrefix(String prefix){
        PreparedStatementCreator preparedStatementCreator = new PreparedStatementCreator() {
            @Override
            public PreparedStatement createPreparedStatement(Connection con) throws SQLException {
                String query = "DELETE FROM Profiles WHERE Profiles.phone_number LIKE ?";
                PreparedStatement ps = con.prepareStatement(query);
                ps.setString(1, prefix + "%");
                return ps;
            }
        };

        jdbc.update(preparedStatementCreator);
    }
}
