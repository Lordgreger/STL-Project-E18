using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleTablets : MonoBehaviour {

    public ArrayList ArrayList;
    private bool startStoreName = false;
    private RiddleInventory pushInventory;
    private RiddleInsert insertTest;
    public bool activate;
    public Interactable interactable;
	// Use this for initialization
	void Start () {
        //Access RiddleInventory script
        pushInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<RiddleInventory>();
        insertTest = GameObject.FindGameObjectWithTag("Placeholders").GetComponent<RiddleInsert>();
        interactable = this.GetComponent<Interactable>();
        activate = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(startStoreName == true){
            if(Input.GetKeyDown(KeyCode.R) && pushInventory.inventory == ""){
                pushInventory.StoreName(this.name);
                pushInventory.riddleTablets.Add(this.gameObject);
                Debug.Log("added to list");
                this.gameObject.SetActive(false);
                startStoreName = false;
                interactable.enabled = false;
            }
            if (Input.GetKeyDown(KeyCode.R) && pushInventory.inventory == "" && insertTest.isPlaced == true)
            {
                pushInventory.StoreName(this.name);
                pushInventory.riddleTablets.Add(this.gameObject);
                Debug.Log("added to list");
                this.gameObject.SetActive(false);
                Debug.Log("false");
                insertTest.isCorrect = 2;
                insertTest.isPlaced = false;
                startStoreName = false;

            }
        }
	}
	
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        { 
            Debug.Log("collided");
            startStoreName = true;
        }
    }

	private void OnTriggerExit2D(Collider2D collision)
	{
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Exit");
            startStoreName = false;
        }

	}
}
