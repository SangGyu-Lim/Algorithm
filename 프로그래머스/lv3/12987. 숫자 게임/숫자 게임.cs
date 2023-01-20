using System;

public class Solution {
    public int solution(int[] A, int[] B) {
        int answer = 0;
        
        Array.Sort(A);
        Array.Reverse(A);
        Array.Sort(B);
        Array.Reverse(B);

        bool isAbleWin = true;
        int aStartNum = 0;
        for(int i = 0; i < B.Length; ++i)
        {
            for(int k = aStartNum; k < A.Length; ++k)
            {
                if(B[i] > A[k])
                {
                    ++answer;
                    aStartNum = k + 1;
                    break;
                }

                if(k == A.Length - 1)
                    isAbleWin = false;
            }

            if (isAbleWin == false)
                break;
        }
        return answer;
    }
}