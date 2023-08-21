package com.example.JDBCBenchmark.repository;

import lombok.AllArgsConstructor;
import lombok.NoArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Repository;

@Repository
@NoArgsConstructor
@AllArgsConstructor
public class PostRepository {

    @Autowired
    private JdbcTemplate jdbc;
}
