using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLeverScript : BooleanLogic {

    public Sprite onSprite;
    public Sprite offSprite;
    public Light onLight;
    public Light offLight;
    public bool startState;

    public SpriteRenderer rend;

	void Start () {
        state = startState;
        updateVisuals(state);
	}

    void updateVisuals(bool state) {
        if (state) {
            rend.sprite = onSprite;
            onLight.enabled = true;
            offLight.enabled = false;
        }
        else {
            rend.sprite = offSprite;
            onLight.enabled = false;
            offLight.enabled = true;
        }
    }

    public void OnInteraction() {
        //print("Interacted with this!");
        state = !state;
        //print("State is now " + state);
        updateVisuals(state);
        onChange.Invoke();
    }

}
