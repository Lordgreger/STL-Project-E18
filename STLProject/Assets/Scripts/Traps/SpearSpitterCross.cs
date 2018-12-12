using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearSpitterCross : ArrowCreator {
    public float cooldown;
    public bool inRange;
    public int mode;

    bool alternateState;

    private void Start() {
        inRange = false;
        StartCoroutine(fire());
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            inRange = false;
        }
    }

    IEnumerator fire() {
        while (true) {
            if (inRange) {
                if (mode == 0) {
                    createCross();
                }
                else if(mode == 1) {
                    createPlus();
                }
                else if (mode == 2) {
                    createAlternate();
                }
                yield return new WaitForSeconds(cooldown);
            }
            else {
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    void createCross() {
        target = new Vector3(1, 1) + transform.position;
        createArrow();
        target = new Vector3(-1, -1) + transform.position;
        createArrow();
        target = new Vector3(1, -1) + transform.position;
        createArrow();
        target = new Vector3(-1, 1) + transform.position;
        createArrow();
    }

    void createPlus() {
        target = new Vector3(1, 0) + transform.position;
        createArrow();
        target = new Vector3(-1, 0) + transform.position;
        createArrow();
        target = new Vector3(0, -1) + transform.position;
        createArrow();
        target = new Vector3(0, 1) + transform.position;
        createArrow();
    }

    void createAlternate() {
        if(alternateState) {
            createCross();
        }
        else {
            createPlus();
        }
        alternateState = !alternateState;
    }

}
