#include <string>
#include <vector>
#include <algorithm>

using namespace std;

void GetLastBalloon(vector<int> currentBalloon, vector<int>* result, bool chance)
{
	if (currentBalloon.size() == 1)
	{
		if (find(result->begin(), result->end(), currentBalloon[0]) == result->end())
			result->push_back(currentBalloon[0]);

		return;
	}

	int size = currentBalloon.size();
	for (int i = 0; i < size - 1; ++i)
	{
		if (chance)
		{
			auto tempChanceBalloon = currentBalloon;
			if (currentBalloon[i] < currentBalloon[i + 1])
				tempChanceBalloon.erase(tempChanceBalloon.begin() + i);
			else
				tempChanceBalloon.erase(tempChanceBalloon.begin() + i + 1);

			GetLastBalloon(tempChanceBalloon, result, false);
		}

		auto tempBalloon = currentBalloon;
		if (currentBalloon[i] > currentBalloon[i + 1])
			tempBalloon.erase(tempBalloon.begin() + i);
		else
			tempBalloon.erase(tempBalloon.begin() + i + 1);

		GetLastBalloon(tempBalloon, result, chance);
	}
}

int solution(vector<int> a) {
    int answer = 0;
	int size = a.size();
	vector<int> overNumCount(size);
	
	int prevMinNum = 0;
	int nextMinNum = 0;
	for (int i = 0; i < size; ++i)
	{
		if (i == 0)
		{
			prevMinNum = a[0];
			nextMinNum = a[size - 1];
			continue;
		}

		if (a[i - 1] < prevMinNum)
			prevMinNum = a[i - 1];

		if (a[size - i] < nextMinNum)
			nextMinNum = a[size - i];

		if (a[i] > prevMinNum)
			++overNumCount[i];

		if (a[size - i - 1] > nextMinNum)
			++overNumCount[size - i - 1];
	}

	auto iter = overNumCount.begin();
	for(; iter != overNumCount.end(); ++iter)
	{
		if (*iter < 2)
			++answer;
	}
    
    return answer;
}