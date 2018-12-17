using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    public RectTransform rt;
    public Rigidbody2D rb;
    float lifetime, damage;
    bool active = false;

    public AudioClip arrowSound;
    private AudioSource source;


    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void setupArrow(Vector3 target, float speed, float lifetime, float damage) {
        pointTowardsTarget(target);
        rb.velocity = (target - transform.position).normalized * speed;
        this.lifetime = lifetime;
        this.damage = damage;
        active = true;
        source.PlayOneShot(arrowSound);
    }

    void pointTowardsTarget(Vector3 target) {
        /*
        rt.LookAt(target);
        if ((transform.position.x - target.transform.position.x) < 0)
            rt.rotation = Quaternion.Euler(0, 0, rt.rotation.eulerAngles.x - 90f);
        else
            rt.rotation = Quaternion.Euler(0, 0, rt.rotation.eulerAngles.x - 90f);
        */
        Vector3 toTarget = (transform.position - target);
        float angle = Mathf.Atan2(toTarget.y, toTarget.x) * Mathf.Rad2Deg;
        rt.Rotate(new Vector3(0, 0, 1), angle + 90.0f);
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
