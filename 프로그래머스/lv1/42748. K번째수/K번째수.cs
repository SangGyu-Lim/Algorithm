using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] array, int[,] commands) {
        int[] answer = new int[commands.GetLength(0)];
        
        for(int i = 0; i < commands.GetLength(0); ++i)
        {
            List<int> list = new List<int>();
            for(int k = commands[i, 0] - 1; k < commands[i, 1]; ++k)
            {
                list.Add(array[k]);
            }
            list.Sort();
            
            answer[i] = list[commands[i, 2] - 1];
        }
        return answer;
    }
}