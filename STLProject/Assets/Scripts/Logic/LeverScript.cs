using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : BooleanLogic {

    public Sprite onSprite;
    public Sprite offSprite;
    public bool startState;

    public SpriteRenderer rend;

    public AudioClip interactSound;
    private AudioSource source;


    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start () {
        state = startState;
        updateVisuals(state);
	}

    void updateVisuals(bool state) {
        if (state) {
            if(rend.sprite == offSprite){
                source.PlayOneShot(interactSound, 0.2f);
            }
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
