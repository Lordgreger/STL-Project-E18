using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearSpitter : ArrowCreator {
    private void Start() {
        target = target + transform.position;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            createArrow();
        }
    }

}
