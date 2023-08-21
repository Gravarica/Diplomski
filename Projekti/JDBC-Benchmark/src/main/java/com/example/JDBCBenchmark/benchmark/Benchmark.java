package com.example.JDBCBenchmark.benchmark;

import com.example.JDBCBenchmark.mappers.UserMapper;
import com.example.JDBCBenchmark.model.User;
import com.example.JDBCBenchmark.repository.PostRepository;
import com.example.JDBCBenchmark.repository.ProfileRepository;
import com.example.JDBCBenchmark.repository.TagRepository;
import com.example.JDBCBenchmark.repository.UserRepository;
import com.example.JDBCBenchmark.util.ResultWriter;
import com.example.HibernateBenchmark.util.Stopwatch;
import lombok.NoArgsConstructor;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

@RequiredArgsConstructor
@Service
public class Benchmark {

    private final UserRepository userRepository;

    private final ProfileRepository profileRepository;

    private final PostRepository postRepository;

    private final TagRepository tagRepository;

    private final Stopwatch stopwatch = new Stopwatch();

    public void runAll() {
        executeFirstReadQuery();
        executeSecondReadQuery();
    }

    public void executeFirstReadQuery(){

        ResultWriter.writeHeader("Get users born after given year.");

        stopwatch.start();

        var users = userRepository.findByDateOfBirthAfter(LocalDate.of(2000,12,31));

        stopwatch.stop();

        ResultWriter.writeFooter(users.size(), stopwatch.getElapsedMilliseconds());
    }

    public void executeSecondReadQuery() {

        ResultWriter.writeHeader("Get number of posts for each user.");

        stopwatch.start();

        var users = userRepository.findUsersWithPostCount();

        stopwatch.stop();

        ResultWriter.writeFooter(users.size(), stopwatch.getElapsedMilliseconds());
    }

    public void testConnectionQuery() {

        ResultWriter.writeHeader("Test again.");

        stopwatch.start();

        var users = userRepository.firstQueryNative();

        stopwatch.stop();

        ResultWriter.writeFooter(users.size(), stopwatch.getElapsedMilliseconds());
    }
}
