import math

# Smallest mathematically possible sum for a pythagorean triplet
SMALLEST_POSSIBLE_SUM = 12


def pythagorean_triplet_by_sum(sum: int):
    # A pythagorean triple is resembles the sides of a 90 degree triangle, and it means that for the sides a, b, c a^2 + b^2 = c^2 and that a+b>c
    # the Formula for a pythagorean triplet is a = 2st, b = s^2 - t^2, c = s^2 + t^2 where a,b,c are the numbers in the triplet and s,t are natural numbers - s < t
    MAX_T = sum // 6
    s = 1
    t = 2
    while t <= MAX_T:
        while s < t:
            a = 2 * s * t
            b = int(math.pow(t, 2) - math.pow(s, 2))
            c = int(math.pow(t, 2) + math.pow(s, 2))
            if a + b + c == sum:
                print(str(sorted([a, b, c]))[1:-1])
            s += 1
        s = 1
        t += 1
