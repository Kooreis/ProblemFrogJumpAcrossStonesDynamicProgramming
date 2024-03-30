Here is a JavaScript solution for the frog jump problem using dynamic programming:

```javascript
function canCross(stones) {
    if (stones[1] !== 1) return false;
    const dp = Array.from({ length: stones.length }, () => new Set());
    dp[1].add(1);
    for (let i = 2; i < stones.length; i++) {
        for (let j = 1; j < i; j++) {
            const diff = stones[i] - stones[j];
            if (dp[j].has(diff) || dp[j].has(diff - 1) || dp[j].has(diff + 1)) {
                dp[i].add(diff);
            }
        }
    }
    return dp[stones.length - 1].size > 0;
}

console.log(canCross([0, 1, 3, 5, 6, 8, 12, 17])); // true
console.log(canCross([0, 1, 2, 3, 4, 8, 9, 11])); // false
```

This solution uses dynamic programming to keep track of all possible jump distances at each stone. If the frog can reach the last stone with any of the jump distances, it returns true. Otherwise, it returns false.