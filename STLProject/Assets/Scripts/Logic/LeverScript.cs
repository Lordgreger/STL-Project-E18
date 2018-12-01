using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : BooleanLogic {

    public Sprite onSprite;
    public Sprite offSprite;
    public bool startState;

    public SpriteRenderer rend;

	void Start () {
        state = startState;
        updateVisuals(state);
	}

    void updateVisuals(bool state) {
        if (state) {
            rend.sprite = onSprite;
        }
        else {
            rend.sprite = offSprite;
        }
    }

    public void OnInteraction() {
        state = !state;
        updateVisuals(state);
        onChange.Invoke();
    }

}
