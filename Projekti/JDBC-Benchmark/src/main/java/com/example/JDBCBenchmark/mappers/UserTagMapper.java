package com.example.JDBCBenchmark.mappers;

import com.example.JDBCBenchmark.dto.UserPostCount;
import com.example.JDBCBenchmark.dto.UserTag;
import com.example.JDBCBenchmark.model.User;
import org.springframework.jdbc.core.RowMapper;

import java.sql.ResultSet;
import java.sql.SQLException;

public class UserTagMapper implements RowMapper<UserTag> {
    @Override
    public UserTag mapRow(ResultSet rs, int rowNum) throws SQLException {

        UserTag userTag = new UserTag();

        userTag.setUserId(rs.getInt(1));
        userTag.setTagCount(rs.getInt(2));

        return userTag;
    }
}
