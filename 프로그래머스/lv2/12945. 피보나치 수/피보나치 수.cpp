#include <string>
#include <vector>

using namespace std;

#define remainder 1234567

int GetFibonacci(int target, int current, int prevNum, int prevPrevNum)
{
	if (target == current)
		return (prevNum + prevPrevNum) % remainder;

	return GetFibonacci(target, current + 1, (prevNum + prevPrevNum) % remainder, prevNum % remainder) % remainder;
}

int solution(int n) {
    int answer = 0;
    
    answer = GetFibonacci(n, 2, 1, 0);
    
    return answer;
}