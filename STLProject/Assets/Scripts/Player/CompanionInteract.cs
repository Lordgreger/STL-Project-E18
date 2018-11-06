using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CompanionInteract : MonoBehaviour {

    // Companion 1
    public CompanionInterface c1;
    public TextMeshProUGUI c1InteractionText;
    public Animator c1Ani;
    public CompanionInteractable c1ActiveInteractable;

    // Companion 2
    public CompanionInterface c2;
    public TextMeshProUGUI c2InteractionText;
    public Animator c2Ani;
    public CompanionInteractable c2ActiveInteractable;

    CompanionInteractable currentInteractable;

    private void Start() {
        currentInteractable = null;

        c1InteractionText.text = "";
        c1.companionMovement.onStateChange.AddListener(updateC1);
        c1ActiveInteractable = null;

        c2InteractionText.text = "";
        c2.companionMovement.onStateChange.AddListener(updateC2);
        c2ActiveInteractable = null;
    }

    private void Update() {
        if (currentInteractable != null) {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                currentInteractable.interact(c1);
            }
        }
    }

    public void setInteractable(CompanionInteractable interactable) {
        currentInteractable = interactable;
        updateC1();
    }

    public void removeInteractable(CompanionInteractable interactable) {
        if (currentInteractable == interactable) {
            //Debug.Log("Got called!");
            currentInteractable = null;
            c1Ani.SetBool("Active", false);
        }
    }

    void updateC1() {
        if (currentInteractable != null) {
            if (c1.companionMovement.isFollowing() && ()) {
                c1InteractionText.text = "[Q] " + c1.companionName + " " + currentInteractable.interactionText;
                c1Ani.SetBool("Active", true);
            }
            else if (c1.companionMovement.isMoving()) {
                c1Ani.SetBool("Active", false);
            }
            else {
                if (c1ActiveInteractable == currentInteractable) {
                    c1InteractionText.text = "[Q] " + c1.companionName + " follow me";
                    c1Ani.SetBool("Active", true);
                }
                c1InteractionText.text = "[Q] " + c1.companionName + " follow me";
                c1Ani.SetBool("Active", true);
            }
        }
        else {
            c1Ani.SetBool("Active", false);
            c2Ani.SetBool("Active", false);
        }
    }

}
