using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTrapFloor : MonoBehaviour {
    protected List<Health> onTrap = new List<Health>();

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Companion") {
            onTrap.Add(col.gameObject.GetComponent<Health>());
            print("On Trap: " + onTrap.Count);
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Companion") {
            onTrap.Remove(col.gameObject.GetComponent<Health>());
            print("On Trap: " + onTrap.Count);
        }
    }
}
