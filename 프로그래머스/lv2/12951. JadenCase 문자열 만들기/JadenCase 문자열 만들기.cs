public class Solution {
    public string solution(string s) {
        string answer = "";
        bool isFirstWord = true;
        
        for(int i = 0; i < s.Length; ++i)
        {
            if(isFirstWord)
            {
                isFirstWord = false;
                if(s[i] >= 'a' && s[i] <= 'z')
                    answer += ((char)(s[i] - 32)).ToString();
                else
                    answer += s[i];
            }
            else
            {
                if(s[i] >= 'A' && s[i] <= 'Z')
                    answer += ((char)(s[i] + 32)).ToString();
                else
                    answer += s[i];
            }
            
            if(s[i] == ' ')
                isFirstWord = true;
        }
        
        return answer;
    }
}