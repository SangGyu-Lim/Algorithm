using System;
using System.Collections.Generic;

class Solution
{
    public int solution(int n, int[] stations, int w){
        int answer =0;

        int startStation = 1;
        int stationAbleLength = (w * 2) + 1;
        int stationsLength = stations.Length;
        for (int i = 0; i < stationsLength; ++i)
        {
            int currentStation = stations[i];
            int max = currentStation + w > n ? n : currentStation + w;
            int min = currentStation - w < 1 ? 1 : currentStation - w;

            int notContainLength = min - startStation;
            if(notContainLength > 0)
            {
                if (notContainLength % stationAbleLength == 0)
                    answer += (notContainLength / stationAbleLength);
                else
                    answer += (notContainLength / stationAbleLength) + 1;
            }

            startStation = max + 1;
        }

        if(startStation <= n)
        {
            int notContainLength = n - startStation + 1;
            if (notContainLength > 0)
            {
                if (notContainLength % stationAbleLength == 0)
                    answer += (notContainLength / stationAbleLength);
                else
                    answer += (notContainLength / stationAbleLength) + 1;
            }
        }

        return answer;
    }
}