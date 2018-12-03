using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicDoor : MonoBehaviour {
    public SpriteRenderer rend;
    public Collider2D col;
    public Sprite open;
    public Sprite closed;

    protected void setDoor(bool isOpen) {
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
