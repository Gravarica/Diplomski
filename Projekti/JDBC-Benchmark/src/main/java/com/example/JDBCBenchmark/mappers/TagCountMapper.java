package com.example.JDBCBenchmark.mappers;

import com.example.JDBCBenchmark.dto.TagCount;
import com.example.JDBCBenchmark.dto.UserPostCount;
import org.springframework.jdbc.core.RowMapper;

import java.sql.ResultSet;
import java.sql.SQLException;

public class TagCountMapper implements RowMapper<TagCount> {
    @Override
    public TagCount mapRow(ResultSet rs, int rowNum) throws SQLException {

        TagCount tagCount = new TagCount();

        tagCount.setTagName(rs.getString(1));
        tagCount.setPostCount(rs.getInt(2));

        return tagCount;
    }
}
