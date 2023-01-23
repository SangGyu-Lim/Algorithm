using System;

public class Solution {
    public int[] solution(string s) {
        int changeBinaryCount = 0;
        int removeZeroCount = 0;
        
        while(true)
        {
            if(s.Length == 1)
                break;
            
            removeZeroCount += (s.Split('0').Length - 1);
            s = s.Replace("0", "");
            
            s = Convert.ToString(s.Length, 2);   
            ++changeBinaryCount;
        }
        
        int[] answer = new int[] {changeBinaryCount, removeZeroCount};
        return answer;
    }
}