using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedPressurePlate : TimedBooleanLogic {

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
        if (col.gameObject.tag == "Player") { // Player entered collider
            setState(!stableState);
            updateVisuals(state);
            timerPaused = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        print("Exited collider!");
        if (col.gameObject.tag == "Player") { // Player exited collider
            timerPaused = false;
        }
    }

    protected override void onTimerDone() {
        updateVisuals(state);
    }

}
