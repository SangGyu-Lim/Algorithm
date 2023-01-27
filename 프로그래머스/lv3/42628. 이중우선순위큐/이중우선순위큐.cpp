#include <string>
#include <vector>
#include <queue>

using namespace std;

vector<int> solution(vector<string> operations) {
    vector<int> answer;
	priority_queue<int> maxQueue;
	priority_queue<int> minQueue;

	int queueCurrentCount = 0;
	auto iter = operations.begin();
	for (; iter != operations.end(); ++iter)
	{
		string str = *iter;
		if (str[0] == 'I')
		{
			int num = stoi(str.substr(2, str.length() - 2));

			maxQueue.push(num);
			minQueue.push(-num);

			++queueCurrentCount;
		}
		else if (queueCurrentCount != 0)
		{
			if (str == "D 1")
			{
				maxQueue.pop();

				--queueCurrentCount;
			}
			else if (str == "D -1")
			{
				minQueue.pop();

				--queueCurrentCount;
			}
		}

		if (queueCurrentCount == 0)
		{
			while (true)
			{
				if (maxQueue.size() == 0)
					break;
			
				maxQueue.pop();
			}

			while (true)
			{
				if (minQueue.size() == 0)
					break;

				minQueue.pop();
			}
		}
	}

	if (queueCurrentCount == 0)
	{
		answer.push_back(0);
		answer.push_back(0);
	}
	else
	{
		answer.push_back(maxQueue.top());
		answer.push_back(-minQueue.top());
	}
    
    return answer;
}