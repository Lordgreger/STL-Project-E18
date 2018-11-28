using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb;
    public SpriteRenderer rend;

    float currentSpeed;

    void Start() {
        currentSpeed = speed;
    }

    void Update () {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector2 input = new Vector2(inputX, inputY);

        if (input.magnitude > 1.0f)
            input = input.normalized;

        rb.velocity = input * currentSpeed;
	}

    public void addTimedSlowEffect(float time) {
        StartCoroutine(slowEffect(time));
    }

    IEnumerator slowEffect(float time) {
        currentSpeed = speed / 4;
        yield return new WaitForSeconds(time);
        currentSpeed = speed;
    }
}
