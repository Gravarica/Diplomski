package com.example.HibernateBenchmark.util;

public class Stopwatch {
    private long startTime = 0;
    private long endTime = 0;

    public void start() {
        this.startTime = System.currentTimeMillis();
    }

    public void stop() {
        this.endTime = System.currentTimeMillis();
    }

    public long getElapsedMilliseconds() {
        return endTime - startTime;
    }

    public double getElapsedSeconds() {
        return ((double)(endTime - startTime)) / 1000;
    }
}
