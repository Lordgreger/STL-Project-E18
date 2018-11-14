using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFloorTrap : MonoBehaviour {

    public float damage;
    public float damageCooldown;
    public Collider2D col;

    bool active = true;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Companion") {
            if (active) {
                onTriggerTrap();
                active = false;
                StartCoroutine(resetCooldown());
            }
        }
    }

    IEnumerator resetCooldown() {
        yield return new WaitForSeconds(damageCooldown);
        active = true;
    }

    public virtual void onTriggerTrap() {
        print("Trap Triggered");
    }

}
