package com.example.JDBCBenchmark.mappers;

import com.example.JDBCBenchmark.dto.UserPostCount;
import org.springframework.jdbc.core.RowMapper;

import java.sql.ResultSet;
import java.sql.SQLException;

public class UserPostCountMapper implements RowMapper<UserPostCount> {
    @Override
    public UserPostCount mapRow(ResultSet rs, int rowNum) throws SQLException {

        UserPostCount userPostCount = new UserPostCount();
        userPostCount.setUserId(rs.getInt(1));
        userPostCount.setEmail(rs.getString(2));
        userPostCount.setPostCount(rs.getInt(3));

        return userPostCount;
    }
}
