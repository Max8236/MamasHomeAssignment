import math

# Smallest mathematically possible sum for a pythagorean triplet
SMALLEST_POSSIBLE_SUM = 12
# S has to be a natural number - the smallest natural number is 1. and we know that t has to be bigger than s and also a natural number
# meaning the smallest possible number is 2
SMALLEST_POSSIBLE_S = 1
SMALLEST_POSSIBLE_T = 2


def pythagorean_triplet_by_sum(sum: int) -> None:
    """
    The function receives a sum and prints all the pythagorean triplets that their sum equals the sum received
    :param sum: the sum of the pythagorean triplet
    :type sum: int
    """
    # According to wikipedia - https://en.wikipedia.org/wiki/Pythagorean_triple
    # the Formula for a pythagorean triplet is a = 2st, b = s^2 - t^2, c = s^2 + t^2 where a,b,c are the numbers in the triplet and s,t are natural numbers - s < t

    # The max size for the t variable that can be used for our case(a pythagorean triplet sum)can be found if we divide the sum by 6 because
    # we know that a < b < c, and we know that the max size of a can be b-1(they have to be natural numbers) which can be c-1(max b size)
    # so we know that the max size of a has to be smaller than sum/3(max size case - if we call a=x than b=x+1 and c=x+2 than the max sum will be 3x+3 / 3 = x+1
    # meaning a < x+1 -> a=x - a has to be smaller than a third of our sum because we know that a < b < c
    # we can use this conclusion to know what numbers we shouldn't check when we generate triplets using our formula
    # if we look at the max size of t that can be suit for a relevant triplet we receive it when s is min meaning s = 1
    # if we look at the formula we can see that a=2st -> a=2*1*t -> 2t -> if max a is sum/3 than 2t = sum/3 /2 -> max t = sum/6
    max_t = sum // 6
    s = SMALLEST_POSSIBLE_S
    t = SMALLEST_POSSIBLE_T

    while t <= max_t:
        while s < t:
            a = 2 * s * t
            b = int(math.pow(t, 2) - math.pow(s, 2))
            c = int(math.pow(t, 2) + math.pow(s, 2))
            if a + b + c == sum:
                print(str(sorted([a, b, c]))[1:-1])     # printing the sorted triplet
            s += 1
        s = SMALLEST_POSSIBLE_S
        t += 1
