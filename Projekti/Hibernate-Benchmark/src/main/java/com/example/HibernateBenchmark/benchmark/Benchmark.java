package com.example.HibernateBenchmark.benchmark;

import com.example.HibernateBenchmark.model.User;
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
import org.springframework.transaction.annotation.Transactional;
import org.springframework.transaction.interceptor.TransactionAspectSupport;

import java.time.LocalDate;

@RequiredArgsConstructor
@Service
public class Benchmark {

    private final UserRepository userRepository;

    private final ProfileRepository profileRepository;

    private final PostRepository postRepository;

    private final TagRepository tagRepository;

    private final Stopwatch stopwatch = new Stopwatch();

    public void runAll(int times) {
        executeFirstQuery(times);
        //executeSecondQuery(times);
        //executeThirdQuery(times);
        //executeFourthQuery(times);
        //executeFifthQuery(times);
        //executeSixthQuery(times);
        //executeSeventhQuery(times);
        //executeEightQuery(times);
        //executeNinthQuery(times);
        //executeTenthQuery(times);
    }

    public void executeFirstQuery(int times){

        ResultWriter.writeHeader("Q1");

        long totalMilliseconds = 0;

        for (int i = 0; i < times; i++) {
            stopwatch.start();

            var users = userRepository.findByDateOfBirthAfter(LocalDate.of(2000,12,31));

            stopwatch.stop();

            totalMilliseconds += stopwatch.getElapsedMilliseconds();
        }

        double average = (double) totalMilliseconds / times;
        ResultWriter.writeAverageFooter(average);
    }

    public void executeSecondQuery(int times) {

        ResultWriter.writeHeader("Q2");
        long totalMilliseconds = 0;

        for (int i = 0; i < times; i++) {
            stopwatch.start();

            var users = userRepository.findUsersWithPostCount();

            stopwatch.stop();

            totalMilliseconds += stopwatch.getElapsedMilliseconds();
        }

        double average = (double) totalMilliseconds / times;
        ResultWriter.writeAverageFooter(average);
    }

    public void executeThirdQuery(int times) {

        ResultWriter.writeHeader("Q3");
        long totalMilliseconds = 0;

        for (int i = 0; i < times; i++) {
            stopwatch.start();

            var users = userRepository.findTopPosters();

            stopwatch.stop();

            totalMilliseconds += stopwatch.getElapsedMilliseconds();
        }

        double average = (double) totalMilliseconds / times;
        ResultWriter.writeAverageFooter(average);
    }

    public void executeFourthQuery(int times) {

        ResultWriter.writeHeader("Q4");
        long totalMilliseconds = 0;

        for (int i = 0; i < times; i++) {
            stopwatch.start();

            var users = userRepository.findUsersByBioKeyword("59");

            stopwatch.stop();

            totalMilliseconds += stopwatch.getElapsedMilliseconds();
        }

        double average = (double) totalMilliseconds / times;
        ResultWriter.writeAverageFooter(average);
    }

    public void executeFifthQuery(int times) {

        ResultWriter.writeHeader("Q5");
        long totalMilliseconds = 0;

        for (int i = 0; i < times; i++) {
            stopwatch.start();

            User newUser = new User();
            newUser.setFirstName("Peroni");
            newUser.setLastName("Peric");
            newUser.setEmail("pera@examplic.com");
            newUser.setDateOfBirth(LocalDate.of(2000, 12, 20));

            userRepository.save(newUser);

            stopwatch.stop();

            totalMilliseconds += stopwatch.getElapsedMilliseconds();
        }

        double average = (double) totalMilliseconds / times;
        ResultWriter.writeAverageFooter(average);
    }

    public void executeSixthQuery(int times) {

        ResultWriter.writeHeader("Q6");
        long totalMilliseconds = 0;

        for (int i = 0; i < times; i++) {
            stopwatch.start();

            var tags = tagRepository.countPostsPerTag();

            stopwatch.stop();

            totalMilliseconds += stopwatch.getElapsedMilliseconds();
        }

        double average = (double) totalMilliseconds / times;
        ResultWriter.writeAverageFooter(average);
    }

    public void executeSeventhQuery(int times) {

        ResultWriter.writeHeader("Q7");
        long totalMilliseconds = 0;

        for (int i = 0; i < times; i++) {
            stopwatch.start();

            var tags = tagRepository.countTagsPerUser();

            stopwatch.stop();

            totalMilliseconds += stopwatch.getElapsedMilliseconds();
        }

        double average = (double) totalMilliseconds / times;
        ResultWriter.writeAverageFooter(average);
    }

    public void executeEightQuery(int times) {

        ResultWriter.writeHeader("Q8");
        long totalMilliseconds = 0;

        for (int i = 0; i < times; i++) {
            stopwatch.start();

            var tags = tagRepository.findDistinctTagsByEmail("user199@example.com");

            stopwatch.stop();

            totalMilliseconds += stopwatch.getElapsedMilliseconds();
        }

        double average = (double) totalMilliseconds / times;
        ResultWriter.writeAverageFooter(average);
    }


    public void executeNinthQuery(int times) {

        ResultWriter.writeHeader("Q9");
        long totalMilliseconds = 0;

        for (int i = 0; i < times; i++) {
            stopwatch.start();

            var tags = postRepository.updatePostContentForUser("TEXT", 99);

            stopwatch.stop();

            totalMilliseconds += stopwatch.getElapsedMilliseconds();
        }

        double average = (double) totalMilliseconds / times;
        ResultWriter.writeAverageFooter(average);
    }

    public void executeTenthQuery(int times) {
        ResultWriter.writeHeader("Q10");
        long totalMilliseconds = 0;

        for (int i = 0; i < times; i++) {
            stopwatch.start();

            profileRepository.deleteProfilesByPhonePrefix("58");

            stopwatch.stop();

            totalMilliseconds += stopwatch.getElapsedMilliseconds();
        }

        double average = (double) totalMilliseconds / times;
        ResultWriter.writeAverageFooter(average);
    }
}
