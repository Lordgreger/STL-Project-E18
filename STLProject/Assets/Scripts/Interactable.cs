using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour {

    public string interactionText;
    public UnityEvent onInteract;

    PlayerInteract player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteract>();
    }

    public void interact() {
        //print("Interact!");
        onInteract.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        //print("Entered collider!");
        if (col.gameObject.tag == "Player") { // Player entered collider
            if (enabled) {
                player.setInteractable(this);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        //print("Exited collider!");
        if (col.gameObject.tag == "Player") { // Player exited collider
            if (enabled) {
                player.removeInteractable(this);
            }
        }
    }
}
