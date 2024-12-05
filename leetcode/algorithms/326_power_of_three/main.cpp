class PowerOfThree {
public:
    bool isPowerOfThree(int n) {
        if (n < 1) {
            return false;
        }
        while (n > 1) {
            if (n % 3) {
                return false;
            }
            n /= 3;
        }
        return true;
    }

    // Best Solution 1
    bool bestSolution1(int n) {
        // 1162261467 is 3^19,  3^20 is bigger than int
        return n > 0 && (1162261467 % n == 0);
    }

    // Best Solution 2: Recursive Solution
    bool bestSolution2(int n) {
        return n > 0 && (n == 1 || (n % 3 == 0 && isPowerOfThree(n / 3)));
    }

    // Best Solution 3: Recursive Solution
    bool bestSolution3(int n) {
        if (n > 1)
            while (n % 3 == 0)
                n /= 3;
        return n == 1;
    }
};