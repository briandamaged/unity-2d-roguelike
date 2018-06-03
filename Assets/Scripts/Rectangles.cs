using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Rectangles {

    public static IEnumerable<Vector3> GetSolidPositions(int x1, int y1, int x2, int y2) {
        for (int x = x1; x <= x2; ++x) {
            for (int y = y1; y <= y2; ++y) {
                yield return new Vector3(x, y, 0f);
            }
        }
    }

    public static IEnumerable<Vector3> GetHollowPositions(int x1, int y1, int x2, int y2) {
        for (int x = x1; x <= x2; ++x) {
            yield return new Vector3(x, y1, 0f);
            yield return new Vector3(x, y2, 0f);
        }

        for (int y = y1 + 1; y < y2; ++y) {
            yield return new Vector3(x1, y, 0f);
            yield return new Vector3(x2, y, 0f);
        }
    }


}
