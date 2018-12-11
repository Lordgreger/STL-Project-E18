using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleController : BooleanLogic {
    public List<string> solution;
    public List<string> tabletValues;
    public List<GameObject> tablets;

    List<string> currentSolution;

    string holding;
    int holdingID = -1;

    public void onTabletInteract(int id) {

        if (holdingID > -1)
            tablets[holdingID].SetActive(true);

        holding = tabletValues[id];
        holdingID = id;

        tablets[holdingID].SetActive(false);

    }
	
}
