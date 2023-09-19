package com.example.JDBCBenchmark.repository;

import com.example.JDBCBenchmark.dto.TagCount;
import com.example.JDBCBenchmark.dto.UserTag;
import com.example.JDBCBenchmark.mappers.StringMapper;
import com.example.JDBCBenchmark.mappers.TagCountMapper;
import com.example.JDBCBenchmark.mappers.UserTagMapper;
import lombok.AllArgsConstructor;
import lombok.NoArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.PreparedStatementCreator;
import org.springframework.stereotype.Repository;

import java.sql.Connection;
import java.sql.Date;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.List;

@NoArgsConstructor
@Repository
@AllArgsConstructor
public class TagRepository {

    @Autowired
    private JdbcTemplate jdbc;

    public List<String> findDistinctTagsByEmail(String email) {
        PreparedStatementCreator preparedStatementCreator = new PreparedStatementCreator() {
            @Override
            public PreparedStatement createPreparedStatement(Connection con) throws SQLException {
                String query = "SELECT DISTINCT t.tag_name " +
                        "FROM Users AS u, Posts AS p, Tags AS t, Post_Tags AS pt " +
                        "WHERE u.user_id = p.user_id AND p.post_id = pt.post_id AND t.tag_id = pt.tag_id " +
                        "AND u.email = ?";
                PreparedStatement ps = con.prepareStatement(query);
                ps.setString(1, email);
                return ps;
            }
        };

        return jdbc.query(preparedStatementCreator, new StringMapper());
    }

    public List<TagCount> countPostsPerTag() {
        String query =  "SELECT t.tag_name, COUNT(p.post_id) as total_posts " +
                "FROM Posts as p, Tags as t, Post_Tags as pt " +
                "WHERE p.post_id = pt.post_id AND t.tag_id = pt.tag_id " +
                "GROUP BY t.tag_name " +
                "HAVING total_posts >= 5";

        return jdbc.query(query, new TagCountMapper());
    }

    public List<UserTag> countTagsPerUser() {
        String query =  "SELECT p.user_id, COUNT(pt.tag_id) as total_tags " +
                "FROM Posts as p, Post_Tags as pt " +
                "WHERE p.post_id = pt.post_id " +
                "GROUP BY p.user_id";

        return jdbc.query(query, new UserTagMapper());
    }
}
