def is_sorted_polyndrom(string: str) -> bool:
    """
    The function receives a string and checks if it is a alphanumerically sorted polyndrom and returns a boolean value accordingly
    :param string: the string received
    :type string: str
    :return: a boolean value representing if the string received is A alphanumerically polyndrom
    :rtype: bool
    """
    middle = len(string) // 2  # finding the middle index of the string
    # checking if the string is a polyndrom and adjusting the middle index of the string according to if it's length is even or not
    return string[:middle + len(string) % 2] == string[middle::][::-1] \
           and string[:middle + len(string) % 2] == ''.join(sorted(string[:middle + len(string) % 2]))
    # checking if the polyndrom is sorted alphanumerically - adjusting the middle index of the string according to if it's length is even or not

