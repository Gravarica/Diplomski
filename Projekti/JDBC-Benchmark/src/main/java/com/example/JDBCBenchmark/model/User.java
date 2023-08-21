package com.example.JDBCBenchmark.model;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDate;
import java.util.List;


@Data
@NoArgsConstructor
@AllArgsConstructor
public class User {


    private Integer userId;

    private String firstName;

    private String lastName;

    private String email;

    private LocalDate dateOfBirth;

    private List<Post> posts;
}
