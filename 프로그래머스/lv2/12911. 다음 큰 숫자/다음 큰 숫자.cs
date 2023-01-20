using System;

class Solution 
{
    public int solution(int n)
    {
        int answer = 0;
        
        int nBinaryOneCount = GetBinaryOneCount(n);
        ++n;
        while(true)
        {
            int tempBinaryOneCount = GetBinaryOneCount(n);
            if(nBinaryOneCount == tempBinaryOneCount)
            {
                answer = n;
                break;
            }
            
            ++n;
        }
        
        return answer;
    }
    
    public int GetBinaryOneCount(int n)
    {
        string binaryNum = Convert.ToString(n, 2);
        
        //MatchCollection matches = Regex.Matches(binaryNum, "1");
        //matches.Count;
        return binaryNum.Split('1').Length - 1;
    }
}