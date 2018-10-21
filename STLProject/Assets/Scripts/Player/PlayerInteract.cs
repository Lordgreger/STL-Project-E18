using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour {

    public TextMeshProUGUI interactionText;
    public Animator ani;


    Interactable currentInteractable;

    private void Start() {
        currentInteractable = null;
        interactionText.text = "";
    }

    private void Update() {
        if (currentInteractable != null) {
            if (Input.GetKeyDown(KeyCode.E)) {
                currentInteractable.interact();
            }
        }
    }

    public void setInteractable(Interactable interactable) {
        currentInteractable = interactable;
        interactionText.text = "[E] " + interactable.interactionText;
        ani.SetBool("Active", true);
    }

    public void removeInteractable(Interactable interactable) {
        if (currentInteractable == interactable) {
            Debug.Log("Got called!");
            currentInteractable = null;
            ani.SetBool("Active", false);
        }
    }

}
