using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearTrap : BaseTrapFloor {
    public float damageCooldown;
    public float checkingCooldown;
    public float damage;

    public Sprite notTriggered;
    public Sprite triggered;
    public SpriteRenderer rend;

    private void Start() {
        StartCoroutine(checkTrap());
    }

    IEnumerator checkTrap() {
        while(true) {
            //print("Checked Trap, count: " + onTrap.Count);
            if (onTrap.Count > 0) {
                //print("damaging stuff: " + onTrap.Count);
                foreach (Health h in onTrap) {
                    h.damage(damage);
                    if (h.gameObject.tag == "Player") {
                        h.gameObject.GetComponent<PlayerMovement>().addTimedSlowEffect(0.33f);
                    }
                    //print("Damaged " + h.gameObject.tag + " with " + damage);
                }
                rend.sprite = triggered;
                yield return new WaitForSeconds(damageCooldown * (3f / 4f));
                rend.sprite = notTriggered;
                yield return new WaitForSeconds(damageCooldown * (1f / 4f));
            }
            else {
                yield return new WaitForSeconds(checkingCooldown);
            }
        }
    }
}
