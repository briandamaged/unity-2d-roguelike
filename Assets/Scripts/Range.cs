using System;
using UnityEngine;

using Random = UnityEngine.Random;

[Serializable]
public class Range {

    public int min;
    public int max;

    public Range(int min, int max) {
        this.min = min;
        this.max = max;
    }

    public int PickRandom() {
        return Random.Range(this.min, this.max);
    }

}
