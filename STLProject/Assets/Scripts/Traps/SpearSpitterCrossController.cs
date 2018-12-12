using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearSpitterCrossController : MonoBehaviour {

    public SpearSpitterCross ssc;
    public float alternateCD;
    public List<BooleanLogic> additionBools = new List<BooleanLogic>();

    float playerSetCD;

    private void Start() {
        playerSetCD = ssc.cooldown;
        foreach(BooleanLogic b in additionBools) {
            b.onChange.AddListener(onBooleanChange);
        }
    }

    public void onBooleanChange() {
        int totalMode = 0;
        foreach(BooleanLogic b in additionBools) {
            if (b.getState() == true)
                totalMode++;
        }

        if (totalMode == 2) {
            ssc.cooldown = alternateCD;
        }
        else {
            ssc.cooldown = playerSetCD;
        }

        ssc.mode = totalMode;
    }

    public void disableTrap () {
        ssc.enabled = false;
    }

}
