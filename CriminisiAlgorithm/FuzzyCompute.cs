﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminisiAlgorithm
{
    internal class FuzzyCompute
    {
        public static FuzzyDictionary ComputeFuzzyMembership()
        {
            FuzzyDictionary fuzzyDictionary = new FuzzyDictionary()
            {
                fuzzyMembershipComputed = new Dictionary<int, double>()
            };

            for (int i = 0; i <= Math.Pow(fuzzyDictionary.patchsize, 2); i++)
            {
                if (i <= fuzzyDictionary.a)
                {
                    fuzzyDictionary.fuzzyMembershipComputed.Add(i, 0);
                }
                else if (i > fuzzyDictionary.b)
                {
                    fuzzyDictionary.fuzzyMembershipComputed.Add(i, 1);
                }
                else
                {
                    fuzzyDictionary.fuzzyMembershipComputed.Add(i, (i - fuzzyDictionary.a) * 1.0 / (fuzzyDictionary.b - fuzzyDictionary.a));
                }

            }
            return fuzzyDictionary;
        }
    }
}