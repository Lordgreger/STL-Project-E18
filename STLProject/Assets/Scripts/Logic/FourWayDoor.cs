using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourWayDoor : LogicDoor {
    public List<FourWaySimpel> symbols = new List<FourWaySimpel>();
    public List<int> code = new List<int>();

    private void Start() {
        foreach (FourWaySimpel fws in symbols) {
            fws.onChange.AddListener(updateDoor);
        }
	}

	private void updateDoor() {
        for (int i = 0; i < symbols.Count; i++){
            if (symbols[i].getState() != code[i]){
                setDoor(false);
                return;
            }
        }
        setDoor(true);
    }
}
