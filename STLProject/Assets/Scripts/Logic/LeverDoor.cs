using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverDoor : MonoBehaviour {

    public List<BooleanLogic> levers = new List<BooleanLogic>();
    public SpriteRenderer rend;
    public Collider2D col;
    public Sprite open;
    public Sprite closed;

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

    void setDoor(bool isOpen) {
        if (isOpen) {
            rend.sprite = open;
            col.enabled = false;
        }
        else {
            rend.sprite = closed;
            col.enabled = true;
        }
    }
}
