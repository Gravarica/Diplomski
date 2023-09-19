package com.example.HibernateBenchmark.dto;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

public interface TagCount {

    String getTagName();
    int getPostCount();
}
