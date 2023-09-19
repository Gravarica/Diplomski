package com.example.HibernateBenchmark.repository;

import com.example.HibernateBenchmark.dto.TagCount;
import com.example.HibernateBenchmark.model.Tag;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.util.List;

public interface TagRepository extends JpaRepository<Tag, Integer> {

    @Query("SELECT DISTINCT t.name FROM User u JOIN u.posts p JOIN p.tags t WHERE u.email = :email")
    List<String> findDistinctTagsByEmail(@Param("email") String email);

    @Query("SELECT t.name, COUNT(p.postId) FROM Post p JOIN p.tags t GROUP BY t.name HAVING COUNT(p.postId) >= 5")
    List<TagCount> countPostsPerTag();

    @Query("SELECT p.user.userId, COUNT(t.tagId) FROM Post p JOIN p.tags t GROUP BY p.user")
    List<Object[]> countTagsPerUser();
}
