using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleDoor : LogicDoor {

    public bool state;

    private void Start() {
        setDoor(state);
    }

    public void toogle() {
        state = !state;
        setDoor(state);
    } 

    public void setState(bool b) {
        state = b;
        setDoor(state);
    }
}
