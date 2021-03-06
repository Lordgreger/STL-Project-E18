﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearSpitterPlayerTarget : ArrowCreator {
    public float cooldown;
    public bool inRange;

    Transform pTrans;

    private void Start() {
        inRange = false;
        StartCoroutine(fire());
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            pTrans = col.gameObject.transform;
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
                target = pTrans.position;
                createArrow();
                yield return new WaitForSeconds(cooldown);
            }
            else {
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
