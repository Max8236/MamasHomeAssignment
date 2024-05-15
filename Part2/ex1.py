ONE_DIGIT = 1


def num_len(num: int) -> int:
    """
    The function receives A integer and returns its length using recursion
    :param num: a natural number
    :type num: int
    :return: number of digits in num
    :rtype: int
    """
    return ONE_DIGIT if num // 10 == 0 else ONE_DIGIT + num_len(num // 10)
