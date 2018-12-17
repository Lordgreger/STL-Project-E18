using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb;
    public SpriteRenderer rend;

    float currentSpeed;

    private Animator animator;


    void Start()
    {
        currentSpeed = speed;

        animator = GetComponent<Animator>();
    }

    void Update () {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector2 input = new Vector2(inputX, inputY);

        if (input.magnitude > 1.0f)
            input = input.normalized;

        rb.velocity = input * currentSpeed;
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x);
        if (rb.velocity.magnitude > 0.0f)
        {
            if (((Mathf.PI) / 4) < angle && angle < (3 * (Mathf.PI) / 4))
            {
                animator.SetTrigger("PlayerWalkUp");
            }
            if (-((Mathf.PI) / 4) > angle && angle > -(3 * (Mathf.PI) / 4))
            {
                animator.SetTrigger("PlayerWalkDown");
            }
            if (-((Mathf.PI) / 4) < angle && angle < ((Mathf.PI) / 4))
            {
                animator.SetTrigger("PlayerWalkRight");
            }
            if (angle > (3 * (Mathf.PI) / 4) || angle < -(3 * (Mathf.PI) / 4))
            {
                animator.SetTrigger("PlayerWalkLeft");
            }
        }
        else
        {
            animator.SetTrigger("PlayerIdle");

        }

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
