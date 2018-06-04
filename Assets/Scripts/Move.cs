using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Move {

    public static IEnumerator Linear(Rigidbody2D rb, Vector2 dest, float time = 1f, Action onComplete = null) {
        float inverseTime = 1f / time;

        while(true) {
            float remaining = (rb.position - dest).sqrMagnitude;
            if(remaining < float.Epsilon) {
                break;
            }

            Vector2 delta = Vector2.MoveTowards(rb.position, dest, inverseTime * Time.deltaTime);
            rb.MovePosition(delta);

            yield return null;
        }

        if(onComplete != null) {
            onComplete();
        }
    }
}
