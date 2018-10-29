using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionMovement : MonoBehaviour {

    public Transform player;
    public Transform target;
    public float speed;
    public float minStoppingDistance;
    public float minFollowDistance;
    public float minTargetDistanceTeleport;
    public Rigidbody2D rb;

    enum State { following, moving, waiting }

    private State state;

    private void Start() {
        state = State.following;
    }

    private void Update() {
        runState();

        if (Input.GetKeyDown(KeyCode.Q)) {
            if (state == State.following) {
                state = State.moving;
            }
            else if (state == State.waiting) {
                state = State.following;
            }
        }
    }

    void runState() {
        switch (state) {
            case State.following:
                stateFollowing();
                break;

            case State.moving:
                stateMoving();
                break;

            case State.waiting:
                break;

            default:
                break;
        }

    }

    void stateFollowing() {
        // Find vector difference to player
        Vector3 dif = player.position - transform.position;

        //Debug.Log("diff mag: " + dif.magnitude);

        // Check if dif is large enough for need of movement
        if (dif.magnitude > minFollowDistance) {
            rb.velocity = dif.normalized * speed;
        }
        else if (dif.magnitude < minStoppingDistance) {
            rb.velocity = Vector2.zero;
        }
        else {
            rb.velocity = rb.velocity.magnitude * dif.normalized;
        }
    }

    void stateMoving() {
        Vector3 dif = target.position - transform.position;

        if (dif.magnitude > minTargetDistanceTeleport) {
            rb.velocity = dif.normalized * speed;
        }
        else {
            transform.position = target.position;
            rb.velocity = Vector2.zero;
            state = State.waiting;
        }
    }
}
