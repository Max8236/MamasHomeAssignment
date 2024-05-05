STOP_RECEIVING_INPUT = -1


def main():
    input_list = []
    temp_input = int(input("Enter a number: "))
    while temp_input != STOP_RECEIVING_INPUT:
        input_list.append(temp_input)
        temp_input = int(input("Enter a number: "))
    print("Average : " + str(sum(input_list) / len(input_list)))
    print("Positive numbers: " + str(sum([1 if num > 0 else 0 for num in input_list])))
    print("Sorted list of numbers: " + str(sorted(input_list)))


if __name__ == "__main__":
    main()
