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
        interactionText.text = "[E] " + interactable.interactionText;
        ani.SetBool("Active", true);
    }

    public void removeInteractable(CompanionInteractable interactable) {
        if (currentInteractable == interactable) {
            Debug.Log("Got called!");
            currentInteractable = null;
            ani.SetBool("Active", false);
        }
    }

}
