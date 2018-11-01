using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedPressurePlateDoor : MonoBehaviour {

    public List<BooleanLogic> plates = new List<BooleanLogic>();

    public Collider2D col;
    public SpriteRenderer rend;

    public Sprite open;
    public Sprite closed;

    private void Start() {
        foreach(BooleanLogic l in plates) {
            l.onChange.AddListener(checkSolution);
        }
        rend.sprite = closed;
    }

    void checkSolution() {
        foreach (BooleanLogic l in plates) {
            if (!l.getState()) {
                return;
            }
        }
        col.enabled = false;
        rend.sprite = open;
        this.enabled = false;
    }

}
