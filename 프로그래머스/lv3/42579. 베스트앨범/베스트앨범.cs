using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(string[] genres, int[] plays) {
        
        int answerTotalCount = 0;
        int genreMaxCount = 2;
        Dictionary<string, int> genresCount = new Dictionary<string, int>();
        Dictionary<string, List<KeyValuePair<int, int>>> genresDetail = new Dictionary<string, List<KeyValuePair<int, int>>>();
        for (int i = 0; i < genres.Length; ++i)
        {
            string genre = genres[i];
            if (genresCount.ContainsKey(genre) == false)
            {
                genresCount.Add(genre, plays[i]);
                ++answerTotalCount;

                List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();
                KeyValuePair<int, int> pair = new KeyValuePair<int, int>(plays[i], i);

                list.Add(pair);
                genresDetail.Add(genre, list);
            }
            else
            {
                genresCount[genre] += plays[i];

                var list = genresDetail[genre];
                if(list.Count >= genreMaxCount)
                {
                    list.Sort(delegate (KeyValuePair<int, int> pair1, KeyValuePair<int, int> pair2)
                    {
                        return pair1.Key.CompareTo(pair2.Key);
                    });

                    for (int k = 0; k < list.Count; ++k)
                    {
                        var temp = list[k];
                        if(plays[i] > temp.Key)
                        {
                            list.Remove(temp);
                            KeyValuePair<int, int> pair = new KeyValuePair<int, int>(plays[i], i);

                            list.Add(pair);
                            genresDetail[genre] = list;
                            break;
                        }
                    }
                }
                else
                {
                    ++answerTotalCount;
                    KeyValuePair<int, int> pair = new KeyValuePair<int, int>(plays[i], i);

                    list.Add(pair);
                    genresDetail[genre] = list;
                }
            }
        }

        int answerCurrentCount = 0;
        int[] answer = new int[answerTotalCount];
        var sortGenresCount = genresCount.OrderByDescending(x => x.Value);
        foreach (var item in sortGenresCount)
        {
            string genre = item.Key;
            var list = genresDetail[genre];
            bool isSameKey = false;
            list.Sort(delegate (KeyValuePair<int, int> pair1, KeyValuePair<int, int> pair2)
            {
                if(pair1.Key == pair2.Key)
                    isSameKey = true;

                return pair1.Key.CompareTo(pair2.Key);
            });
            if(isSameKey == false)
                list.Reverse();

            for (int i = 0; i < list.Count; ++i)
            {
                answer[answerCurrentCount] = list[i].Value;
                ++answerCurrentCount;
            }
        }
        
        return answer;
    }
}