using System;
using System.Linq;

public class Solution {
    public int[] solution(int[] lottos, int[] win_nums) {
        int[] answer = new int[] {};
        
        int zeroCount = 0;
        int correctCount = 0;
        for(int i = 0; i < lottos.Length; ++i)
        {
            if(lottos[i] == 0)
            {
                ++zeroCount;
                continue;
            }
            else if(win_nums.Contains(lottos[i]))
            {
                ++correctCount;
            }
        }
        
        int max = 0;
        int min = 0;
        if((correctCount + zeroCount) == 0)
            max = 1;
        if(correctCount == 0)
            min = 1;
        
        int[] temp = {7 - (correctCount + zeroCount + max), 7 - (correctCount + min)};
        answer = temp;
        
        return answer;
    }
}