using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : BooleanLogic {

    public Sprite onSprite;
    public Sprite offSprite;

    public SpriteRenderer rend;

    public CompanionInteractable companionInteractable;
    public string[] companionTexts;

    public int minWeightToActivate;

    int weight;

    private void Start() {
        if (companionInteractable != null) {
            companionInteractable.onInteract.AddListener(onCompanionInteract);
        }
        weight = 0;
    }

    

    void updateVisuals(bool state) {
        if (state) {
            rend.sprite = onSprite;
        }
        else {
            rend.sprite = offSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        //print("Entered collider!");
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Companion") { // Player entered collider
            weight++;
            getNewState();
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        //print("Exited collider!");
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Companion") { // Player exited collider
            weight--;
            getNewState();
        }
    }

    void getNewState() {
        if (!state) { // Plate is false
            if (weight >= minWeightToActivate) { // Weight signals true
                state = true;
                onChange.Invoke();
                updateVisuals(state);
            }
        }
        else { // Plate is true
            if (weight < minWeightToActivate) { // weight signals false
                state = false;
                weight = 0; // In case weight somehow gets negative we reset
                onChange.Invoke();
                updateVisuals(state);
            }
        }
    }

    void onCompanionInteract(CompanionInterface i) {
        if (i.companionMovement.isFollowing()) {
            companionInteractable.interactionText = companionTexts[1];
            companionInteractable.currentUser = i.companionID;
            i.companionMovement.setTargetAndMove(transform);
        }
        else {
            companionInteractable.interactionText = companionTexts[0];
            companionInteractable.currentUser = "";
            i.companionMovement.release(transform);
        }
    }
}
