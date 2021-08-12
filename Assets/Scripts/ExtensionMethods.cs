using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static T RandomElement<T>(this List<T> value)
        {
            return value[Random.Range(0, value.Count)];
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> value)
        {
            return value.OrderBy(x => Random.value);
        }
    }

}