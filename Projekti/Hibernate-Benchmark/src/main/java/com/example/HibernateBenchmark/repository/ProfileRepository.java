package com.example.HibernateBenchmark.repository;

import com.example.HibernateBenchmark.model.Profile;
import com.example.HibernateBenchmark.model.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.transaction.annotation.Transactional;

public interface ProfileRepository extends JpaRepository<Profile, Integer> {

    @Modifying
    @Transactional
    @Query("DELETE FROM Profile p WHERE p.phoneNumber LIKE :prefix%")
    int deleteProfilesByPhonePrefix(@Param("prefix") String prefix);
}
