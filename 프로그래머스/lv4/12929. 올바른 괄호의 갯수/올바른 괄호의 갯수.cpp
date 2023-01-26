#include <string>
#include <vector>

using namespace std;

#define LEFT_BRACKET "("
#define RIGHT_BRACKET ")"

void SetBracket(int leftCount, int rightCount, vector<string> str, vector<string>* answer)
{
	if (leftCount == 0 && rightCount == 0)
	{
		string temp = "";
		vector<string>::iterator iter = str.begin();
		for (; iter != str.end(); ++iter)
		{
			temp += *iter;
		}

		answer->push_back(temp);

		return;
	}

	if (leftCount > 0)
	{
		str.push_back(LEFT_BRACKET);
		--leftCount;

		if (leftCount != 0)
			SetBracket(leftCount, rightCount, str, answer);
	}
	if (rightCount > 0)
	{
		if (leftCount > 0)
		{
			for (int i = 0; i < (rightCount - leftCount); ++i)
			{
				str.push_back(RIGHT_BRACKET);
				SetBracket(leftCount, rightCount - (i + 1), str, answer);
			}
		}
		else
		{
			str.push_back(RIGHT_BRACKET);
			SetBracket(leftCount, rightCount - 1, str, answer);
		}
	}

}

int solution(int n) {
    vector<string> answer = {};
	vector<string> temp = {};

	SetBracket(n, n, temp, &answer);

	return answer.size();
}