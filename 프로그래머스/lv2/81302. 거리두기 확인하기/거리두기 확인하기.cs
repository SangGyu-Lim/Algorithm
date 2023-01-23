using System;
using System.Linq;
using System.Collections.Generic;

public class Solution {
    public int[] solution(string[,] places) {
        
         int[] answer = new int[] { };
            answer = new int[places.GetLength(0)];
            for (int i = 0; i < places.GetLength(0); i++)
            {
                List<string> roomdata = new List<string>();
                for (int j = 0; j < places.GetLength(1); j++)
                {
                    string seatdata = places[i, j];
                    roomdata.Add(seatdata);
                }
                answer[i] = checkManhaeton(roomdata);
            }
            return answer;
    }
    
    public int checkManhaeton(List<string> roomdata)
        {
            for (int i = 0; i < roomdata.Count; i++)
            {
                for (int j = 0; j < roomdata.Count; j++)
                {
                    if (roomdata[i][j] == 'P')
                    {
                        //1칸
                        //우 하
                        if (i < 4 && roomdata[i + 1][j] == 'P') return 0;
                        if (j < 4 && roomdata[i][j + 1] == 'P') return 0;
                        //2칸
                        if (i < 3 && roomdata[i + 2][j] == 'P')
                        {
                            if(roomdata[i+1][j] !='X') return 0;
                        }
                        if (j < 3 && roomdata[i][j + 2] == 'P') 
                        {
                            if (roomdata[i][j + 1] != 'X') return 0;
                        }
                        //대각 우하
                        if(i<4 && j<4 && roomdata[i+1][j+1] =='P')
                        {
                            if (roomdata[i + 1][j] != 'X' || roomdata[i][j + 1] != 'X') return 0;
                        }
                        //대각 좌하
                        else if(i < 4 && j>0 && roomdata[i+1][j-1] == 'P')
                        {
                            if (roomdata[i + 1][j] != 'X' || roomdata[i][j - 1] != 'X') return 0;
                        }
                    }
                }
            }
            return 1;
        }
}