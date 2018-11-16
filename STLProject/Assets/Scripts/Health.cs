using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float maxHealth;

    public float health;


    private void Start() {
        health = maxHealth;
    }

    public void damage(float damage) {
        health -= damage;
    }
}
