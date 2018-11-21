using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearTrap : BaseTrapFloor {
    public float damageCooldown;
    public float checkingCooldown;
    public float damage;

    private void Start() {
        StartCoroutine(checkTrap());
    }

    IEnumerator checkTrap() {
        while(true) {
            print("Checked Trap, count: " + onTrap.Count);
            if (onTrap.Count > 0) {
                print("damaging stuff: " + onTrap.Count);
                foreach (Health h in onTrap) {
                    h.damage(damage);
                    print("Damaged " + h.gameObject.tag + " with " + damage);
                }
                yield return new WaitForSeconds(damageCooldown);
            }
            else {
                yield return new WaitForSeconds(checkingCooldown);
            }
        }
    }
}
