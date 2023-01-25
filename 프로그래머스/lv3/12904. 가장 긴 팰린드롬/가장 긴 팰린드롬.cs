public class Solution {
    public int solution(string s) {
        int answer = 1;

        for(int i = 1; i < s.Length - 1; ++i)
        {
            // 홀수
            int currentLength = 1;
            bool isPalindrome = false;
            while (true)
            {
                if (i - currentLength < 0 || i + currentLength > s.Length - 1)
                    break;

                if (s[i - currentLength] == s[i + currentLength])
                {
                    ++currentLength;
                    isPalindrome = true;
                }
                else
                    break;
            }

            if(isPalindrome)
            {
                int palindromeLength = (currentLength - 1) * 2 + 1;
                if (palindromeLength > answer)
                    answer = palindromeLength;

                if (palindromeLength == s.Length)
                    break;
            }

            // 짝수
            currentLength = 0;
            isPalindrome = false;
            while (true)
            {
                if (i - currentLength < 0 || i + currentLength + 1 > s.Length - 1)
                    break;

                if (s[i - currentLength] == s[i + currentLength + 1])
                {
                    ++currentLength;
                    isPalindrome = true;
                }
                else
                    break;
            }

            if (isPalindrome)
            {
                int palindromeLength = currentLength * 2;
                if (palindromeLength > answer)
                    answer = palindromeLength;

                if (palindromeLength == s.Length)
                    break;
            }
        }

        return answer;
    }
}