using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicDoor : MonoBehaviour {
    public SpriteRenderer rend;
    public Collider2D col;
    public Sprite open;
    public Sprite closed;

    public AudioClip doorSound;
    private AudioSource source;


    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }


    protected void setDoor(bool isOpen) {
        if (isOpen) {
            if(rend.sprite==closed){
                source.PlayOneShot(doorSound);
            }
            rend.sprite = open;
            col.enabled = false;
        }
        else {
            rend.sprite = closed;
            col.enabled = true;
        }
    }
}
