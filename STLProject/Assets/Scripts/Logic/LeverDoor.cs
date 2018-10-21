using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverDoor : MonoBehaviour {

    public List<BooleanLogic> levers = new List<BooleanLogic>();
    public SpriteRenderer rend;
    public Collider2D col;

    private void Start() {
        foreach(BooleanLogic lever in levers) {
            lever.onChange.AddListener(checkLevers);
        }
    }

    void checkLevers() {
        print("Got lever change!");
        foreach (BooleanLogic lever in levers) {
            if (lever.getState() == false) {
                setDoor(false);
                return;
            }  
        }
        setDoor(true);
    }

    void setDoor(bool open) {
        if (open) {
            rend.enabled = false;
            col.enabled = false;
        }
        else {
            rend.enabled = true;
            col.enabled = true;
        }
    }
}
