package com.example.HibernateBenchmark.repository;

import com.example.HibernateBenchmark.model.Post;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.transaction.annotation.Transactional;

public interface PostRepository extends JpaRepository<Post, Integer> {

    @Modifying
    @Transactional
    @Query("UPDATE Post p SET p.content = :content WHERE p.user.userId = :userId")
    int updatePostContentForUser(@Param("content") String content, @Param("userId") Integer userId);
}
