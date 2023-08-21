package com.example.JDBCBenchmark.model;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDateTime;
import java.util.List;


@Data
@NoArgsConstructor
@AllArgsConstructor
public class Post {

    private Integer postId;

    private String title;

    private String content;

    private LocalDateTime timestamp;

    private User user;

    private List<Tag> tags;
}
