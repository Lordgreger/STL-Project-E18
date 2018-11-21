using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFloorTrap : MonoBehaviour {
    public float cooldown;

    protected bool active = true;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Companion") {
            if (active) {
                onTriggerTrap(collision);
                active = false;
                StartCoroutine(resetCooldown());
            }
        }
    }

    protected IEnumerator resetCooldown() {
        yield return new WaitForSeconds(cooldown);
        active = true;
    }

    public virtual void onTriggerTrap(Collider2D col) {
        print("Trap Triggered");
    }

}
