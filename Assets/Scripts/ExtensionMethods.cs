using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static T RandomElement<T>(this IList<T> value)
        {
            return value[Random.Range(0, value.Count)];
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> value)
        {
            return value.OrderBy(x => Random.value);
        }

        public static bool IsNeighboring(this Vector2Int value, Vector2Int n)
        {
            return Mathf.Abs(value.x - n.x) <= 1 && Mathf.Abs(value.y - n.y) <= 1 && value != n;
        }
    }

}