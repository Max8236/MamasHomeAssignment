def is_sorted_polyndrom(string: str) -> bool:
    middle = len(string) // 2 if len(string) % 2 == 0 else len(string) // 2
    return string[:middle + len(string) % 2] == string[middle::][::-1] and string[:middle+len(string) % 2] == ''.join(sorted(string[:middle+len(string) % 2]))




