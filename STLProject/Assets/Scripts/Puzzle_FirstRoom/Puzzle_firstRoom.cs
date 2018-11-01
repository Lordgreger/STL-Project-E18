using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle_firstRoom : MonoBehaviour {
    private int angle = 0;
    public Text hintText;
    public GameObject fireSymbol;
    public GameObject eyeSymbol;
    public GameObject leafSymbol;
    public GameObject waterSymbol;
    public GameObject firstDoor;
    private bool fireWithinBounds = false;
    private bool eyeWithinBounds = false;
    private bool leafWithinBounds = false;
    private bool waterWithinBounds = false;
    public GameObject hints_1;
    public GameObject hints_2;
    public GameObject hints_3;
    public GameObject hints_4;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (fireSymbol.transform.eulerAngles.z == angle && eyeSymbol.transform.eulerAngles.z == angle && leafSymbol.transform.eulerAngles.z == angle && waterSymbol.transform.eulerAngles.z == angle)
        {
            Destroy(firstDoor);
        }

        if(fireWithinBounds == true){
            if (Input.GetKeyDown(KeyCode.E))
            {
                fireSymbol.transform.Rotate(Vector3.forward * -90);

            }
        }

        if (eyeWithinBounds == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                eyeSymbol.transform.Rotate(Vector3.forward * -90);
               
            }
        }

        if (leafWithinBounds == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                leafSymbol.transform.Rotate(Vector3.forward * -90);

            }
        }

        if (waterWithinBounds == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                waterSymbol.transform.Rotate(Vector3.forward * -90);

            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "leverFire")
            {
                fireWithinBounds = true;
                
            }
            
            if (collision.gameObject.tag == "leverEye")
            {
                eyeWithinBounds = true;
               
            }

            if (collision.gameObject.tag == "leverLeaf")
            {
                leafWithinBounds = true;
               
            }

            if (collision.gameObject.tag == "leverWater")
            {
                waterWithinBounds = true;
                
            }
            
           
        }

	private void OnTriggerExit2D(Collider2D collision)
	{
        if(collision.gameObject.tag == "leverFire"){
            fireWithinBounds = false;
           
        }
        if (collision.gameObject.tag == "leverEye")
        {
            eyeWithinBounds = false;
           
        }
        if (collision.gameObject.tag == "leverLeaf")
        {
            leafWithinBounds = false;

        }
        if (collision.gameObject.tag == "leverWater")
        {
            waterWithinBounds = false;
        }
   
	}

	public IEnumerator OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "hint 1")
        {
            hintText.text = "[E] Interact";
            yield return new WaitForSeconds(3f);
            hintText.text = "";
            Destroy(hints_1);
        }
        if (collision.gameObject.tag == "hint 2")
        {
            hintText.text = "[E] Interact";
            yield return new WaitForSeconds(3f);
            hintText.text = "";
            Destroy(hints_2);
        }
        if (collision.gameObject.tag == "hint 3")
        {
            hintText.text = "[E] Interact";
            yield return new WaitForSeconds(3f);
            hintText.text = "";
            Destroy(hints_3);
        }
        if (collision.gameObject.tag == "hint 4")
        {
            hintText.text = "[E] Interact";
            yield return new WaitForSeconds(3f);
            hintText.text = "";
            Destroy(hints_4);
        }
	} 
	

}
