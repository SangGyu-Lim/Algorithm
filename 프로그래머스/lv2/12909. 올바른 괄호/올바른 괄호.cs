using System;

public class Solution {
    public bool solution(string s) {
        bool answer = true;
        
        int openBracketCount = 0;
        for(int i = 0; i < s.Length; ++i)
        {
            if(s[i] == '(')
                ++openBracketCount;
            else
            {
                --openBracketCount;
                if(openBracketCount < 0)
                {
                    answer = false;
                    break;
                }
            }
        }
        
        if(openBracketCount > 0)
            answer = false;
        
        return answer;
    }
}