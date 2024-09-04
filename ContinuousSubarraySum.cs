public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {
        // Check for edge cases when k is 0 and there are consecutive zeros
        for (int i = 1; i < nums.Length; i++) {
            if (nums[i] == 0 && nums[i - 1] == 0) {
                return true;
            }
        }
        
        // Handle cases where k is 0 or 1
        if (k == 0 || k == 1) {
            for (int i = 1; i < nums.Length; i++) {
                if (nums[i] == nums[i - 1]) {
                    return true;
                }
            }
        }
        
        // Use a dictionary to track running sum mod k
        var remainderMap = new Dictionary<int, int>();
        remainderMap[0] = -1; // Initial condition: sum of 0 at "index" -1
        int sum = 0;
        
        for (int i = 0; i < nums.Length; i++) {
            sum += nums[i];
            int remainder = k == 0 ? sum : sum % k;
            
            if (remainderMap.ContainsKey(remainder)) {
                if (i - remainderMap[remainder] > 1) {
                    return true;
                }
            } else {
                remainderMap[remainder] = i;
            }
        }
        
        return false;
    }
}
