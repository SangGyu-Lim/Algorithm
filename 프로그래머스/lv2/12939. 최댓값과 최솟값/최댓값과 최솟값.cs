public class Solution {
    public string solution(string s) {
        int maxNum = 0, minNum = 0;
        
        string[] numList = s.Split(' ');
        for(int i = 0; i < numList.Length; ++i)
        {
            int currentNum = int.Parse(numList[i]);
            if(i == 0)
            {
                maxNum = currentNum;
                minNum = currentNum;
            }
            else
            {
                if(currentNum > maxNum)
                    maxNum = currentNum;
                if(currentNum < minNum)
                    minNum = currentNum;
            }
        }
        string answer = minNum.ToString() + " " + maxNum.ToString();
        return answer;
    }
}