package com.example.HibernateBenchmark.repository;

import com.example.HibernateBenchmark.model.Tag;
import org.springframework.data.jpa.repository.JpaRepository;

public interface TagRepository extends JpaRepository<Tag, Integer> {

}
