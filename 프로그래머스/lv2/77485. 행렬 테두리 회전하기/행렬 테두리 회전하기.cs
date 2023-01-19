using System;

public class Solution {
    public int[] solution(int rows, int columns, int[,] queries) {
        int[] answer = new int[queries.GetLength(0)];
        int[,] arr = new int[rows, columns];
        int count = 1;
        for (int i = 0; i < rows; ++i)
        {
            for (int k = 0; k < columns; ++k)
            {
                arr[i, k] = count;
                ++count;
            }
        }

        for (int i = 0; i < queries.GetLength(0); ++i)
        {
            int x1 = queries[i, 0];
            int y1 = queries[i, 1];
            int x2 = queries[i, 2];
            int y2 = queries[i, 3];

            int minNum = rows * columns;
            int lastNum = 0;
            int tempPos = x1 - 1;
            for (int k = y1 - 1; k < y2 - 1; ++k)
            {
                int tempLastNum = lastNum;
                lastNum = arr[tempPos, k + 1];
                if (k == y1 - 1)
                    arr[tempPos, k + 1] = arr[tempPos, k];
                else
                    arr[tempPos, k + 1] = tempLastNum;
                
                if (minNum > arr[tempPos, k + 1])
                    minNum = arr[tempPos, k + 1];
            }

            tempPos = y2 - 1;
            for (int k = x1; k <= x2 - 1; ++k)
            {
                int tempLastNum = lastNum;
                lastNum = arr[k, tempPos];
                arr[k, tempPos] = tempLastNum;

                if (minNum > arr[k, tempPos])
                    minNum = arr[k, tempPos];
            }

            tempPos = x2 - 1;
            for (int k = y2 - 2; k >= y1 - 1; --k)
            {
                int tempLastNum = lastNum;
                lastNum = arr[tempPos, k];
                arr[tempPos, k] = tempLastNum;

                if (minNum > arr[tempPos, k])
                    minNum = arr[tempPos, k];
            }

            tempPos = y1 - 1;
            for (int k = x2 - 2; k >= x1 - 1; --k)
            {
                int tempLastNum = lastNum;
                lastNum = arr[k, tempPos];
                arr[k, tempPos] = tempLastNum;

                if (minNum > arr[k, tempPos])
                    minNum = arr[k, tempPos];
            }

            answer[i] = minNum;
        }
        
        return answer;
    }
}