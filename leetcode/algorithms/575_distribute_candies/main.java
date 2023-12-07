import java.util.Arrays;
import java.util.BitSet;
import java.util.HashSet;
import java.util.Set;

class DistributeCandies {
    public int distributeCandies(int[] candyType) {
        return Math.min(candyType.length / 2, Arrays.stream(candyType).distinct().toArray().length);
    }


    // Best Solution
    // HashSet
    public int bestSolution1(int[] candyType) {
        Set<Integer> kinds = new HashSet<Integer>();
        for (int candy : candyType) {
            kinds.add(candy);
        }
        return kinds.size() >= candyType.length / 2 ? candyType.length / 2 : kinds.size();
    }

    // Boolean array
    public int bestSolution2(int[] candyType) {
        boolean[] type = new boolean[200001];
        int count = 0, max = candyType.length / 2;
        for (int candy : candyType) {
            int t = candy + 100000;
            if (!type[t]) {
                if (++count == max) {
                    return max;
                }
                type[t] = true;
            }
        }
        return count;
    }

    // BitSet
    public int bestSolution3(int[] candyType) {
        BitSet bits = new BitSet(200001);
        int count = 0, max = candyType.length / 2;
        for (int candy : candyType) {
            int t = candy + 100000;
            if (!bits.get(t)) {
                if (++count == max) {
                    return max;
                }
                bits.set(t);
            }
        }
        return count;
    }

}