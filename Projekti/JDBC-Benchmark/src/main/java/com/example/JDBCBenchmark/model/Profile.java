package com.example.JDBCBenchmark.model;


import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class Profile {

    private Integer profileId;

    private String address;

    private String phoneNumber;

    private String bio;

    private User user;

}
