package com.example.HibernateBenchmark.repository;

import com.example.HibernateBenchmark.dto.UserPostCount;
import com.example.HibernateBenchmark.model.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.time.LocalDate;
import java.util.List;

public interface UserRepository extends JpaRepository<User, Integer> {

    List<User> findByDateOfBirthAfter(LocalDate year);

    List<User> findByUserIdGreaterThan(Integer id);

    @Query(value = "SELECT u FROM User u WHERE u.dateOfBirth > :year")
    List<User> getUsersBornAfter(@Param("year") LocalDate year);

    @Query( "SELECT new com.example.HibernateBenchmark.dto.UserPostCount(u.userId, u.email, size(u.posts))" +
            "FROM User u")
    List<UserPostCount> findUsersWithPostCount();
}
