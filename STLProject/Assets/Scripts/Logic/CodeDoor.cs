using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeDoor : LeverDoor {

    public string code;

    protected override void checkLevers() {
        //print("Got lever change!");
        string input = "";
        foreach (BooleanLogic lever in levers) {
            if (lever.getState()) {
                input += "1";
            }
            else {
                input += "0";
            }
        }

        if (input == code) {
            setDoor(true);
        }
        else {
            setDoor(false);
        }
    }
	
}
