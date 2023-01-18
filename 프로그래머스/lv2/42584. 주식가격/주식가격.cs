using System;

public class Solution {
    public int[] solution(int[] prices) {
        int[] answer = new int[prices.Length];
        
        for(int i = 0; i < prices.Length; ++i)
        {
            int noDownSec = 0;
            for(int k = i + 1; k < prices.Length; ++k)
            {
                ++noDownSec;
                if(prices[i] > prices[k])
                    break;
            }
            
            answer[i] = noDownSec;
        }
        
        return answer;
    }
}