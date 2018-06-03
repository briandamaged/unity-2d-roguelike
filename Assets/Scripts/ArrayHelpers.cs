
using System;
using System.Collections;
using System.Collections.Generic;

using Random = UnityEngine.Random;

static class ArrayHelpers {

    public static T PickRandom<T>(this T[] array) {
        if(array.Length <= 0) {
            throw new InvalidOperationException("PickRandom() invoked on an empty Array");
        }
        int index = Random.Range(0, array.Length - 1);
        return array[index];
    }

    public static T Pop<T>(this IList<T> list) {
        if(list.Count == 0) {
            throw new InvalidOperationException("Cannot Pop an empty IList");
        }

        int lastIndex = list.Count - 1;
        T retval = list[lastIndex];
        list.RemoveAt(lastIndex);

        return retval;
    }


    public static IEnumerable<T> PopUpTo<T>(this IList<T> list, int count) {
        for (int i = 0; i < count; ++i) {
            if(list.Count == 0) {
                yield break;
            }

            yield return list.Pop();
        }
    }


    public static T RandomlyGrab<T>(this IList<T> list) {
        if(list.Count == 0) {
            throw new InvalidOperationException("Cannot RandomlyPick from an empty IList");
        }

        int index = Random.Range(0, list.Count - 1);
        T retval = list[index];
        list.RemoveAt(index);

        return retval;
    }

    public static IEnumerable<T> RandomlyGrabUpTo<T>(this IList<T> list, int count) {
        for (int i = 0; i < count; ++i) {
            if(list.Count == 0) {
                yield break;
            }

            yield return list.RandomlyGrab();
        }
    }


}
