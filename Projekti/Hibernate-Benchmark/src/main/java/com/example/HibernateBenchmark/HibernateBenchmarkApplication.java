package com.example.HibernateBenchmark;

import com.example.HibernateBenchmark.benchmark.Benchmark;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class HibernateBenchmarkApplication implements CommandLineRunner {

	private final Benchmark benchmark;

	public HibernateBenchmarkApplication(Benchmark benchmark) {
		this.benchmark = benchmark;
	}

	public static void main(String[] args) {
		SpringApplication.run(HibernateBenchmarkApplication.class, args);
	}

	@Override
	public void run(String... args) throws Exception {
		benchmark.executeFirstReadQuery();
	}
}
