using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : BooleanLogic {

    public Sprite onSprite;
    public Sprite offSprite;

    public SpriteRenderer rend;

    void updateVisuals(bool state) {
        if (state) {
            rend.sprite = onSprite;
        }
        else {
            rend.sprite = offSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        print("Entered collider!");
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Companion") { // Player entered collider
            state = true;
            onChange.Invoke();
            updateVisuals(state);
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        print("Exited collider!");
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Companion") { // Player exited collider
            state = false;
            onChange.Invoke();
            updateVisuals(state);
        }
    }
}
