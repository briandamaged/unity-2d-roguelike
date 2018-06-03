
using System;
using Random = UnityEngine.Random;

static class ArrayHelpers {

    public static T PickRandom<T>(this T[] array) {
        if(array.Length <= 0) {
            throw new InvalidOperationException("PickRandom() invoked on an empty Array");
        }
        int index = Random.Range(0, array.Length - 1);
        return array[index];
    }
}
