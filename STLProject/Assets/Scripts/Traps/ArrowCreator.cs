using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCreator : MonoBehaviour {

    public GameObject arrowPrefab;
    public float damage, lifetime, speed;
    public Transform target;

	public void createArrow() {
        GameObject arrow = Instantiate(arrowPrefab);
        arrow.transform.position = this.transform.position;
        arrow.GetComponent<Arrow>().setupArrow(target, speed, lifetime, damage);

    }

}
