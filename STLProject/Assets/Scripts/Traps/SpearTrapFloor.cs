using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearTrapFloor : BaseFloorTrap {
    public float damage;
    public Collider2D col;
    public float updateTime;

    bool updateActivator = true;

    public override void onTriggerTrap(Collider2D col) {
        base.onTriggerTrap(col);
        col.gameObject.GetComponent<Health>().damage(damage);
        print("Damaged " + col.gameObject.tag + " with " + damage);
    }

    public void Update() {
        if (active) {
            if (updateActivator) {
                updateCheck();
                updateActivator = false;
                StartCoroutine(resetActivator());
            }
        }
    }

    IEnumerator resetActivator() {
        yield return new WaitForSeconds(updateTime);
        updateActivator = true;
    }

    void updateCheck() {
        print("UPDATED TRAP!");
        Collider2D[] overlaps = {};
        ContactFilter2D cf = new ContactFilter2D();
        cf.SetDepth(-999, 999);
        int numberOfOverlaps = col.OverlapCollider(cf, overlaps);
        print("UPDATED TRAP! GOT " + numberOfOverlaps + " OVERLAPS!");
        List<Collider2D> targets = new List<Collider2D>();

        for (int i = 0; i < numberOfOverlaps; i++) {
            if (overlaps[i].gameObject.tag == "Player" || overlaps[i].gameObject.tag == "Companion") {
                targets.Add(overlaps[i]);
            }
        }

        if (targets.Count > 0) {
            foreach (Collider2D c in targets) {
                onTriggerTrap(c);
            }
            active = false;
            StartCoroutine(resetCooldown());
        }
    }
    private void OnCollisionStay2D(Collision2D collision) {
        
    }
}
