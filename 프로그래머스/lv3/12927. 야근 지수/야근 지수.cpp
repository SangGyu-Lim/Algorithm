#include <string>
#include <vector>
#include <map>

using namespace std;

long long solution(int n, vector<int> works) {
    long long answer = 0;
    int maxNum = 0;
	map<int, int> map;
	for (auto iter = works.begin(); iter != works.end(); ++iter)
	{
		int key = *iter;
		if (map.count(key) == 0)
			map.insert(pair<int, int>(key, 1));
		else
			map[key] += 1;

		if (key > maxNum)
			maxNum = key;
	}

	while (true)
	{
		if (map.count(maxNum) == 0)
		{
			--maxNum;
		}
		else
		{
			int minusCount = 0;
			int currentWork = map[maxNum];
			if (currentWork > n)
			{
				map[maxNum] -= n;
				minusCount = n;
				n = 0;

				if (maxNum > 1)
				{
					if (map.count(maxNum - 1) == 0)
						map.insert(pair<int, int>(maxNum - 1, minusCount));
					else
						map[maxNum - 1] += minusCount;
				}
			}
			else
			{
				map.erase(maxNum);
				minusCount = currentWork;
				n -= currentWork;

				if (maxNum > 1)
				{
					if (map.count(maxNum - 1) == 0)
						map.insert(pair<int, int>(maxNum - 1, minusCount));
					else
						map[maxNum - 1] += minusCount;
				}
				--maxNum;
			}

			
		}

		if (n == 0 || map.empty())
			break;
	}

	for (auto iter = map.begin(); iter != map.end(); ++iter)
	{
		int notWorkTime = (*iter).first;
		int notWorkValue = (*iter).second;

		for (int i = 0; i < notWorkValue; ++i)
			answer += notWorkTime * notWorkTime;
	}
    
    return answer;
}