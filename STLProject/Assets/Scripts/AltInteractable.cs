using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AltInteractable : MonoBehaviour {

    public string key;
    public UnityEvent onInteract;
    bool active;

    private void Start()
    {
        active = false;
    }

    public void interact()
    {
        //print("Interact!");
        onInteract.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //print("Entered collider!");
        if (col.gameObject.tag == "Player")
        { // Player entered collider
            
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        //print("Exited collider!");
        if (col.gameObject.tag == "Player")
        { // Player exited collider
            
        }
    }
}
