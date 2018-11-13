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
        c1.companionMovement.onStateChange.AddListener(updateTexts);
        c2.companionMovement.onStateChange.AddListener(updateTexts);
    }

    private void Update() {
        if (currentInteractable != null) {
            if (currentInteractable.currentUser == c1.companionID) {
                if (Input.GetKeyDown(KeyCode.Alpha1)) {
                    currentInteractable.interact(c1);
                }
            }
            else if (currentInteractable.currentUser == c2.companionID) {
                if (Input.GetKeyDown(KeyCode.Alpha2)) {
                    currentInteractable.interact(c2);
                }
            }
            else {
                if (Input.GetKeyDown(KeyCode.Alpha1)) {
                    currentInteractable.interact(c1);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                    currentInteractable.interact(c2);
                }
            }
        }
    }

    public void setInteractable(CompanionInteractable interactable) {
        currentInteractable = interactable;
        updateTexts();
    }

    public void removeInteractable(CompanionInteractable interactable) {
        if (currentInteractable == interactable) {
            //Debug.Log("Got called!");
            currentInteractable = null;
            updateTexts();
        }
    }

    void updateTexts() {
        if (currentInteractable == null) {
            c1Ani.SetBool("Active", false);
            c2Ani.SetBool("Active", false);
        }
        else if (currentInteractable.currentUser == c1.companionID) {
            c1InteractionText.text = "[1] " + c1.companionName + " " + currentInteractable.interactionText;
            c1Ani.SetBool("Active", true);
            c2Ani.SetBool("Active", false);
        }
        else if (currentInteractable.currentUser == c2.companionID) {
            c1Ani.SetBool("Active", false);
            c2InteractionText.text = "[2] " + c2.companionName + " " + currentInteractable.interactionText;
            c2Ani.SetBool("Active", true);
        }
        else {
            c1InteractionText.text = "[1] " + c1.companionName + " " + currentInteractable.interactionText;
            c1Ani.SetBool("Active", true);
            c2InteractionText.text = "[2] " + c2.companionName + " " + currentInteractable.interactionText;
            c2Ani.SetBool("Active", true);
        }
    }
}
