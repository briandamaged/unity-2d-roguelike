using System;

using System.Collections;
using System.Collections.Generic;

using Random = UnityEngine.Random;

static class IListExtensions {
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
