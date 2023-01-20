#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

int solution(int number, int limit, int power) {
    int answer = 0;
    for(int i = 1; i <= number; ++i)
    {
        int count = 0;
        for(int k = 1; k * k <= i; ++k)
        {
            if(i % k == 0)
            {
                ++count;
                if(k * k < i)
                    ++count;
            }
        }

        if(count > limit)
            answer += power;
        else
            answer += count;
    }
    
    return answer;
}