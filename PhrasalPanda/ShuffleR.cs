﻿using System.Collections.Generic;

namespace PhrasalPanda
{
    public static class Shuffler
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            if (list != null)
            {
                int n = list.Count;
                while (n > 1)
                {
                    n--;
                    int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                    T value = list[k];
                    list[k] = list[n];
                    list[n] = value;
                }
            }
        }
    }
}