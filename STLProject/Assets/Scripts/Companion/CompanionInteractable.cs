using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CompanionInteractionEvent : UnityEvent<CompanionInterface> {};

public class CompanionInteractable : MonoBehaviour {

    public string interactionText;
    public CompanionInteractionEvent onInteract = new CompanionInteractionEvent();

    CompanionInteract player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CompanionInteract>();
    }

    public void interact(CompanionInterface i) {
        print("Interact!");
        onInteract.Invoke(i);
    }

    private void OnTriggerEnter2D(Collider2D col) {
        print("Entered collider!");
        if (col.gameObject.tag == "Player") { // Player entered collider
            player.setInteractable(this);
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        print("Exited collider!");
        if (col.gameObject.tag == "Player") { // Player exited collider
            player.removeInteractable(this);
        }
    }
}
