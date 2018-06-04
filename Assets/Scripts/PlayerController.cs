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
            int dx = 0;
            int dy = 0;

            bool tryMove = false;

            if (Input.GetKeyDown(KeyCode.A)) {
                --dx;
                tryMove = true;
            }

            if (Input.GetKeyDown(KeyCode.D)) {
                ++dx;
                tryMove = true;
            }

            if (Input.GetKeyDown(KeyCode.S)) {
                --dy;
                tryMove = true;
            }

            if (Input.GetKeyDown(KeyCode.W)) {
                ++dy;
                tryMove = true;
            }

            if(tryMove) {

                Vector2 dest = this.rb.position + new Vector2(dx, dy);
                StartCoroutine(Move.Linear(this.rb, dest, 0.1f, () => { this.moving = false; }));

                this.moving = true;

            }


        }


	}
}
