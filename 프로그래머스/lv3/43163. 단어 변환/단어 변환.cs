using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(string begin, string target, string[] words) {
        
        var wordsList = words.ToList();
        int answer = GetChangeWordCount(begin, target, begin.Length, wordsList.ToList(), 0);
        
        return answer;
    }
    
    int GetChangeWordCount(string currentWord, string target, int wordLength, List<string> wordsList, int count)
    {
        if (currentWord == target)
            return count;

        int result = 0;
        for (int i = 0; i < wordsList.Count; ++i)
        {
            string word = wordsList[i];

            bool ableChangeWord = true;
            int differentWordCount = 0;
            for (int k = 0; k < wordLength; ++k)
            {
                if (currentWord[k] != word[k])
                    ++differentWordCount;

                if (differentWordCount > 1)
                {
                    ableChangeWord = false;
                    break;
                }
            }

            if (ableChangeWord)
            {
                var tempList = wordsList.ToList();
                tempList.Remove(word);
                int tempCount = GetChangeWordCount(word, target, wordLength, tempList.ToList(), count + 1);

                if (tempCount != 0)
                {
                    if(result == 0)
                        result = tempCount;
                    else if(result > tempCount)
                        result = tempCount;
                }
            }
        }

        return result;
    }
}