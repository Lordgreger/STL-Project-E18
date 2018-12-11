using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleDrop : MonoBehaviour {

    private RiddleInventory pushInventory;

	// Use this for initialization
	void Start () {
        // Access RiddleInventory script
        pushInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<RiddleInventory>();
	}
	
	// Update is called once per frame
	void Update () {
        //Call function
        DropAndRemove();
	}

    // Empty inventory, drop what is collected and remove from list
    public void DropAndRemove(){
        if (pushInventory.inventory != "" && Input.GetKeyDown(KeyCode.X)){
            pushInventory.inventory = "";
            pushInventory.riddleTablets[0].transform.position = GameObject.FindWithTag("Player").transform.position;
            pushInventory.riddleTablets[0].transform.rotation = GameObject.FindWithTag("Player").transform.rotation;
            pushInventory.riddleTablets[0].SetActive(true);
            pushInventory.riddleTablets.RemoveAt(0);
        }
    }
}
