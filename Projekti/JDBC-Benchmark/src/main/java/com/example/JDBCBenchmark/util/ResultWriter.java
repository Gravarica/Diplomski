package com.example.JDBCBenchmark.util;

public class ResultWriter {

    public static void writeHeader(String query){
        System.out.println("=================================================================");
        System.out.println(" Query: " + query);
        System.out.println(" ----------------------------------------------------------------");
    }

    public static void writeFooter(int count, long time){
        System.out.println(" Total number of records: " + count);
        System.out.println(" Elapsed time: " + time + " ms.");
        System.out.println("=================================================================");
    }

    public static void writeAverageFooter(double average) {
        System.out.println("Finished running tests for query.");
        System.out.println(" Elapsed time: " + Math.round(average*100)/100 + " ms.");
    }
}
