package com.example.HibernateBenchmark.dto;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

public interface UserProfile {

    int getUserId();
    String getEmail();
    String getBio();
}
