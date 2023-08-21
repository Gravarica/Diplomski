package com.example.HibernateBenchmark.dto;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class UserPostCount {

    private Integer userId;
    private String email;
    private Integer postCount;
}
