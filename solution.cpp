```cpp
#include <iostream>
#include <vector>
#include <algorithm>

int frogJump(std::vector<int>& stones) {
    int n = stones.size();
    std::vector<std::vector<int>> dp(n, std::vector<int>(n + 1, 0));
    dp[0][1] = 1;
    for (int i = 1; i < n; ++i) {
        for (int j = 0; j < i; ++j) {
            int diff = stones[i] - stones[j];
            if (diff < -1 || diff > i) continue;
            dp[i][diff] = dp[j][diff - 1] || dp[j][diff] || dp[j][diff + 1];
        }
    }
    for (int i = 1; i < n; ++i) {
        if (dp[n - 1][i]) return true;
    }
    return false;
}

int main() {
    std::vector<int> stones = {0, 1, 3, 5, 6, 8, 12, 17};
    std::cout << (frogJump(stones) ? "True" : "False") << std::endl;
    return 0;
}
```