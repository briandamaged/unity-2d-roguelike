using System;

using System.Collections;
using System.Collections.Generic;

using Random = UnityEngine.Random;

static class IListExtensions {
    /// <summary>
    /// Returns a random element from the IList
    /// </summary>
    /// <returns>A random element from the IList</returns>
    /// <param name="list">List.</param>
    /// <typeparam name="T">The 1st type parameter.</typeparam>
    public static T PickRandom<T>(this IList<T> list) {
        if(list.Count == 0) {
            throw new InvalidOperationException("Cannot PickRandom() from an empty IList");
        }

        int index = Random.Range(0, list.Count);
        return list[index];
    }

    /// <summary>
    /// Returns a random element from the IList.  The element is also removed from the IList.
    /// </summary>
    /// <returns>A random element from the IList</returns>
    /// <param name="list">List.</param>
    /// <typeparam name="T">The 1st type parameter.</typeparam>
    public static T GrabRandom<T>(this IList<T> list) {
        if (list.Count == 0) {
            throw new InvalidOperationException("Cannot GrabRandom from an empty IList");
        }

        int index = Random.Range(0, list.Count);
        T retval = list[index];
        list.RemoveAt(index);

        return retval;
    }
}
