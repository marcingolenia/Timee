﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace Timee
{
    public static class Extensions
    {
        public static IList<T> Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
            return list;
        }
    }
}
