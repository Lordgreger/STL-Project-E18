using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBooleanDoor : MonoBehaviour {

    public SpriteRenderer rend;
    public Collider2D col;

    public void changeState(bool state) {
        rend.enabled = state;
        col.enabled = state;
    }

}
