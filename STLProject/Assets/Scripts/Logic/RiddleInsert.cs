using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleInsert : MonoBehaviour {

    private RiddleInventory getInventory;
    public bool isFull = false;
    // 0 is true, 1 is nothing, 2 is false;
    public int isCorrect;
    public GameObject instantiated;
    public bool insert = false;
    public GameObject placeHolder;
    public bool isPlaced = false;
    public GameObject getCanvas;
    public GameObject canvas;

    // Use this for initialization
	void Start () {
        getInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<RiddleInventory>();
        isCorrect = 1;
	}

    // Update is called once per frame
    void Update()
    {
        if (isCorrect == 0){
            isCorrect = 1;
            getInventory.correctTablets++;
            Debug.Log(getInventory.correctTablets);

        }
        if (isCorrect == 2 && getInventory.correctTablets > 0){
            getInventory.correctTablets--;
            Debug.Log(getInventory.correctTablets);
            isCorrect = 1;
        }

        if(insert == true){
            insertTablet();
        } 
	}

    private void OnTriggerStay2D(Collider2D col)
    {
        // insert tablet
        if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E) && isFull == false && getInventory.inventory != "")
        {
            Debug.Log("I collide");
            isFull = true;
            insert = true;
            isPlaced = true;
            //this get child set active
            this.transform.GetChild(1).gameObject.SetActive(true);
        }

       if (col.gameObject.tag =="Player" && Input.GetKeyDown(KeyCode.R) && getInventory.inventory == "" && isPlaced == true){
            placeHolder = this.transform.transform.GetChild(0).gameObject;
            placeHolder.SetActive(true); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Exit");
            insert = false;
            getCanvas = this.transform.GetChild(0).gameObject;
            canvas = getCanvas.transform.GetChild(0).gameObject;
            canvas.SetActive(true);
        }

    }

    public void CheckTablet(){
        if ("riddleTablet" + this.name == getInventory.inventory)
        {
            isCorrect = 0;
        }
    }

    public void insertTablet(){
        CheckTablet();
        //insert tablet and remove from inventory
        getInventory.inventory = "";
     /* getInventory.riddleTablets[0].transform.position = this.transform.position;
        getInventory.riddleTablets[0].transform.rotation = this.transform.rotation;
        getInventory.riddleTablets[0].SetActive(true); */

        getInventory.riddleTablets.RemoveAt(0);
        placeHolder = this.transform.transform.GetChild(0).gameObject;
        placeHolder.SetActive(false);

    }
}
