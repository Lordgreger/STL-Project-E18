using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    public RectTransform rt;
    public Rigidbody2D rb;
    float lifetime, damage;
    bool active = false;

    public void setupArrow(Transform target, float speed, float lifetime, float damage) {
        rt.LookAt(target);
        rt.rotation = Quaternion.Euler(0, 0, rt.rotation.eulerAngles.x + 90f);
        rb.velocity = target.localPosition.normalized * speed;
        this.lifetime = lifetime;
        this.damage = damage;
        active = true;
    }

    private void Update() {
        if(active) {
            if (lifetime < 0.0f)
                Destroy(gameObject);
            lifetime -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Companion") {
            col.gameObject.GetComponent<Health>().damage(damage);
        }

        if (col.gameObject.tag == "Trap") {
            return;
        }

        Destroy(gameObject);
    }

}
