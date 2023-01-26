using System;
using System.Collections.Generic;

class Solution
{
    public int[] solution(int n, string[] words)
    {
        int failNum = 0;
        int failTurn = 0;
        
        List<string> useWord = new List<string>();
        int currentNum = 1;
        int currentTurn = 1;
        for(int i = 0; i < words.Length; ++i)
        {
            if(i != 0)
            {
                string preWord = words[i - 1];
                if(preWord[preWord.Length - 1] != words[i][0])
                {
                    failNum = currentNum;
                    failTurn = currentTurn;
                    break;
                }
            }
            
            if(useWord.Contains(words[i]))
            {
                failNum = currentNum;
                failTurn = currentTurn;
                break;
            }
            
            useWord.Add(words[i]);
            ++currentNum;
            if(currentNum > n)
            {
                currentNum = 1;
                ++currentTurn;
            }
        }
        
        int[] answer = {failNum, failTurn};
        return answer;
    }
}