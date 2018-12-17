using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float maxHealth;
    public PopUpDisplayer pop;
    private float health;

    public AudioClip painSound, arrowHit;
    private AudioSource source;


    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void Start() {
        health = maxHealth;
    }

    public void damage(float damage) {
        source.PlayOneShot(painSound,0.2f);
        health -= damage;
        pop.spawnText("-"+damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "flyingSpear")
        {
            source.PlayOneShot(arrowHit);
        }
    }
}
