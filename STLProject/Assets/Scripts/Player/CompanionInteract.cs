using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CompanionInteract : MonoBehaviour {

    // Companion 1
    public CompanionInterface c1;
    public TextMeshProUGUI c1InteractionText;
    public Animator c1Ani;

    // Companion 2
    public CompanionInterface c2;
    public TextMeshProUGUI c2InteractionText;
    public Animator c2Ani;

    CompanionInteractable currentInteractable;

    private void Start() {
        currentInteractable = null;

        c1InteractionText.text = "";
        c1.companionMovement.onStateChange.AddListener(updateC1);

        //c2InteractionText.text = "";
        //c2.companionMovement.onStateChange.AddListener(updateC2);
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
            if (currentInteractable.currentUser == c1.companionID || currentInteractable.currentUser == "") {
                c1InteractionText.text = "[1] " + c1.companionName + " " + currentInteractable.interactionText;
                c1Ani.SetBool("Active", true);
                return;
            }
        }
        c1Ani.SetBool("Active", false);
    }
}
