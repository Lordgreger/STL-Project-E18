using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb;
    public SpriteRenderer rend;
    
	void Update () {
        //rend.flipX = Input.GetAxis("Horizontal") > 0.0f;

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector2 input = new Vector2(inputX, inputY);

        if (input.magnitude > 1.0f)
            input = input.normalized;

        rb.velocity = input * speed;
	}
}
