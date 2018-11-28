using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCreator : MonoBehaviour {

    public GameObject arrowPrefab;
    public float damage, lifetime, speed;
    public Transform target;

	public void createArrow() {
        Instantiate(arrowPrefab, transform).GetComponent<Arrow>().setupArrow(target, speed, lifetime, damage);
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            createArrow();
        }     
    }


}
