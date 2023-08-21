package com.example.JDBCBenchmark.repository;

import lombok.AllArgsConstructor;
import lombok.NoArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Repository;

@NoArgsConstructor
@Repository
@AllArgsConstructor
public class TagRepository {

    @Autowired
    private JdbcTemplate jdbc;
}
