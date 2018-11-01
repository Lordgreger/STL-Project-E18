using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    [HideInInspector]
    public UnityEvent onStateChange;

    private void Start() {
        state = State.following;
    }

    private void Update() {
        runState();

        /*
        if (Input.GetKeyDown(KeyCode.Q)) {
            if (state == State.following) {
                state = State.moving;
            }
            else if (state == State.waiting) {
                state = State.following;
            }
        }
        */
    }

    public bool isFollowing() {
        if (state == State.following) {
            return true;
        }
        return false;
    }

    public bool isMoving() {
        if (state == State.moving) {
            return true;
        }
        return false;
    }

    public void setTargetAndMove(Transform t) {
        if (state == State.following) {
            target = t;
            state = State.moving;
            onStateChange.Invoke();
        }
    }

    public void release(Transform t) {
        if (state == State.waiting && target == t) {
            target = null;
            state = State.following;
            onStateChange.Invoke();
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
                stateWaiting();
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
            onStateChange.Invoke();
        }
    }

    void stateWaiting() {
        Vector3 dif = target.position - transform.position;

        if (dif.magnitude > minTargetDistanceTeleport) {
            transform.position = target.position;
            rb.velocity = Vector2.zero;
        }
        else {
            transform.position = target.position;
            rb.velocity = Vector2.zero;
        }
    }
}
