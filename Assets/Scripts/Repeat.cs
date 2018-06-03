using System;
using System.Collections.Generic;

static class Repeat {

    public static void Times(int count, Action action) {
        for (int i = 0; i < count; ++i) {
            action();
        }
    }


    public static IEnumerable<T> Times<T>(int count, Func<T> func) {
        for (int i = 0; i < count; ++i) {
            yield return func();
        }
    }
}
