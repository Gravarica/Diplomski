package com.example.JDBCBenchmark;

import com.example.JDBCBenchmark.benchmark.Benchmark;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class JdbcBenchmarkApplication implements CommandLineRunner {

	private final Benchmark benchmark;

	public JdbcBenchmarkApplication(Benchmark benchmark) {
		this.benchmark = benchmark;
	}

	public static void main(String[] args) {
		SpringApplication.run(JdbcBenchmarkApplication.class, args);
	}


	@Override
	public void run(String... args) throws Exception {
		benchmark.runAll(100);
	}
}
