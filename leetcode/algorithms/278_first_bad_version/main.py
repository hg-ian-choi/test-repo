import math

# The isBadVersion API is already defined for you.
# def isBadVersion(version: int) -> bool:


def isBadVersion(version: int) -> bool:
    return False


class Solution:
    def firstBadVersion(self, n: int) -> int:
        left = 0
        right = n

        while left < right:
            mid = math.floor(left + (right - left) / 2)
            if isBadVersion(mid):
                right = mid
            else:
                left = mid + 1

        return left


    # Best Solution
    def bestSolution(self, n):
        i = 1
        j = n
        while i < j:
            pivot = (i + j) // 2
            if isBadVersion(pivot):
                j = pivot  # keep track of the leftmost bad version
            else:
                i = pivot + 1  # the one after the rightmost good version
        return i
