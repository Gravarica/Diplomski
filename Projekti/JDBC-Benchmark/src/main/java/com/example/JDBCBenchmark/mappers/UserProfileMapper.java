package com.example.JDBCBenchmark.mappers;

import com.example.JDBCBenchmark.dto.UserPostCount;
import com.example.JDBCBenchmark.dto.UserProfile;
import org.springframework.jdbc.core.RowMapper;

import java.sql.ResultSet;
import java.sql.SQLException;

public class UserProfileMapper implements RowMapper<UserProfile> {
    @Override
    public UserProfile mapRow(ResultSet rs, int rowNum) throws SQLException {

        UserProfile userProfile = new UserProfile();
        userProfile.setUserId(rs.getInt(1));
        userProfile.setEmail(rs.getString(2));
        userProfile.setBio((rs.getString(3)));

        return userProfile;
    }
}
