using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CompanionInteract : MonoBehaviour {

    public CompanionInterface c1;
    public TextMeshProUGUI interactionText;
    public Animator ani;

    CompanionInteractable currentInteractable;

    private void Start() {
        currentInteractable = null;
        interactionText.text = "";
        c1.companionMovement.onStateChange.AddListener(updateInteractable);
    }

    private void Update() {
        if (currentInteractable != null) {
            if (Input.GetKeyDown(KeyCode.Q)) {
                currentInteractable.interact(c1);
            }
        }
    }

    public void setInteractable(CompanionInteractable interactable) {
        currentInteractable = interactable;
        updateInteractable();
    }

    public void removeInteractable(CompanionInteractable interactable) {
        if (currentInteractable == interactable) {
            //Debug.Log("Got called!");
            currentInteractable = null;
            ani.SetBool("Active", false);
        }
    }

    void updateInteractable() {
        if (currentInteractable != null) {
            if (c1.companionMovement.isFollowing()) {
                interactionText.text = "[Q] " + c1.companionName + " " + currentInteractable.interactionText;
                ani.SetBool("Active", true);
            }
            else if (c1.companionMovement.isMoving()) {
                ani.SetBool("Active", false);
            }
            else {
                interactionText.text = "[Q] " + c1.companionName + " follow me";
                ani.SetBool("Active", true);
            }
        }
        else {
            ani.SetBool("Active", false);
        }
    }

}
