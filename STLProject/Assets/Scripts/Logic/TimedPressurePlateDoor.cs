using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedPressurePlateDoor : MonoBehaviour {

    public List<BooleanLogic> plates = new List<BooleanLogic>();

    public Collider2D col;
    public SpriteRenderer rend;

    private void Start() {
        foreach(BooleanLogic l in plates) {
            l.onChange.AddListener(checkSolution);
        }
    }

    void checkSolution() {
        foreach (BooleanLogic l in plates) {
            if (!l.getState()) {
                return;
            }
        }
        col.enabled = false;
        rend.enabled = false;
        this.enabled = false;
    }

}
