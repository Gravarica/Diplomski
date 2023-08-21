package com.example.JDBCBenchmark.model;


import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;


@Data
@NoArgsConstructor
@AllArgsConstructor
public class Tag {

    private Integer tagId;

    private String name;

    private List<Post> posts;
}
