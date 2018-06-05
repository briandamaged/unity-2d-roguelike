using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;

    private bool moving;

	// Use this for initialization
	void Start () {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.moving = false;
	}

	// Update is called once per frame
	void Update () {
        if(!this.moving) {
            int dx = (int)Input.GetAxis("Horizontal");
            int dy = (int)Input.GetAxis("Vertical");

            if(dx != 0 || dy != 0) {
                Vector2 dest = this.rb.position + new Vector2(dx, dy);
                StartCoroutine(Move.Linear(this.rb, dest, 0.1f, () => { this.moving = false; }));

                this.moving = true;
            }
        }
	}
}
