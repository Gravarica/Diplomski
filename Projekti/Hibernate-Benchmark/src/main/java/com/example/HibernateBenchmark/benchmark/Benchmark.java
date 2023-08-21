package com.example.HibernateBenchmark.benchmark;

import com.example.HibernateBenchmark.repository.PostRepository;
import com.example.HibernateBenchmark.repository.ProfileRepository;
import com.example.HibernateBenchmark.repository.TagRepository;
import com.example.HibernateBenchmark.repository.UserRepository;
import com.example.HibernateBenchmark.util.ResultWriter;
import com.example.HibernateBenchmark.util.Stopwatch;
import lombok.NoArgsConstructor;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.time.LocalDate;

@RequiredArgsConstructor
@Service
public class Benchmark {

    private final UserRepository userRepository;

    /*private final ProfileRepository profileRepository;

    private final PostRepository postRepository;

    private final TagRepository tagRepository;*/

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
}
