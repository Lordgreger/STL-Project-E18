using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourWayDoor : MonoBehaviour {

    public List<FourWaySimpel> symbols = new List<FourWaySimpel>();
    public List<int> code = new List<int>();
    public SpriteRenderer door;
    public Collider2D doorCollider;


    private void Start()
	{
        foreach (FourWaySimpel fws in symbols)
        {
            fws.onChange.AddListener(updateDoor);
        }
	}


	private void updateDoor(){
        for (int i = 0; i < symbols.Count; i++){
            if (symbols[i].getState() != code[i]){
                door.enabled = true;
                doorCollider.enabled = true;
                return;
            }
        }
        door.enabled = false;
        doorCollider.enabled = false;

    }
}
