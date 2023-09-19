def print_header(query):
    print("=================================================================")
    print(" Query: " + query)
    print(" ----------------------------------------------------------------")


def print_footer(count, time):
    print(" Total number of records: ", count)
    print(" Elapsed time: ", time, " ms.")
    print("=================================================================")


def print_average_footer(average):
    print(" Finished executing queries.")
    print(" Average elapsed time: ", average, "ms. ")
    print("=================================================================")
