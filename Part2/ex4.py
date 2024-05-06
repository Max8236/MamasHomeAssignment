import matplotlib.pyplot as plt
import numpy as np

# constants
STOP_RECEIVING_INPUT = -1
CORRELATION_COEFFICIENT_FIRST_INDEX = 0
CORRELATION_COEFFICIENT_SECOND_INDEX = 1
POSITIVE_NUMBER = 1
NEGATIVE_NUMBER = 0


def input_list_of_numbers() -> list:
    """
    The function inputs number until -1 is entered and returns the list of number inputted
    :return: the number inputted
    :rtype: list
    """
    input_list = []
    temp_input = int(input("Enter a number: "))
    while temp_input != STOP_RECEIVING_INPUT:
        input_list.append(temp_input)
        temp_input = int(input("Enter a number: "))
    return input_list


def calculate_average_of_list(numbers: list) -> float:
    """
    The function receives a list of number and returns the average of the list
    :param numbers: the list of numbers
    :type numbers: list
    :return: the average of the list
    :rtype: float
    """
    return sum(numbers) / len(numbers)


def calculate_num_of_positive_numbers(numbers: list) -> int:
    """
    The function receives a list of numbers and returns the amount of positive numbers in the list
    :param numbers: the list of numbers received
    :type numbers: list
    :return: the number of positive numbers in the list
    :rtype: int
    """
    return sum([POSITIVE_NUMBER if num > 0 else NEGATIVE_NUMBER for num in numbers])


def sort_list_of_numbers(numbers: list) -> list:
    """
    The function receives a list of numbers, sorts it and returns it
    :param numbers: the list of numbers received
    :type numbers: list
    :return: the sorted list of numbers
    :rtype: list
    """
    return sorted(numbers)


def create_graph_of_numbers_list(numbers: list) -> None:
    """
    The function receives a list of numbers, and creates a graph of points resembling the numbers in the list
    the graph also shows the pearson correlation coefficient of the points
    :param numbers: the list of numbers received
    :type numbers: list
    """
    plt.plot(numbers, 'ro')     # adding data to graph and changing its style to a point graph
    plt.ylabel('inputted numbers')
    plt.xlabel('index')
    plt.title('Correlation = ' + "{:.2f}".format(
        calculate_correlation_coefficient(numbers)))  # add pearson correlation Coefficient as the title of the graph
    plt.show()


def calculate_correlation_coefficient(numbers: list) -> float:
    """
    The function receives a list of numbers resembling y values in a graph and calculates the pearson correlation coefficient using numpy and returns it
    :param numbers: the list of numbers received
    :type numbers: list
    :return: the correlation coefficient of the points received
    :rtype; float
    """
    # passing the list of numbers resembling the y points(the list received) and another list that resembles the x values of the points(indexes)
    return np.corrcoef(np.array(numbers), np.array(range(len(numbers))))[
        CORRELATION_COEFFICIENT_FIRST_INDEX, CORRELATION_COEFFICIENT_SECOND_INDEX]


def print_and_input_data() -> None:
    """
    The main function of the program calls all the functions accordingly - inputs numbers, print average, prints amount of positive numbers, prints the sorted list of numbers
    and shows a graph of the points inputted along with the correlation coefficient.
    """
    numbers = input_list_of_numbers()
    print("Average : " + str(calculate_average_of_list(numbers)))
    print("Positive numbers: " + str(calculate_num_of_positive_numbers(numbers)))
    print("Sorted list of numbers: " + str(sort_list_of_numbers(numbers)))
    create_graph_of_numbers_list(numbers)


def main():
    print_and_input_data()


if __name__ == "__main__":
    main()
