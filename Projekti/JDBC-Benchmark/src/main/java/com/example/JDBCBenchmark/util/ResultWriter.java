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
}
