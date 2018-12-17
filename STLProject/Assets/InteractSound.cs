using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSound : MonoBehaviour {


    public AudioClip interactSound;
    private AudioSource source;


    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playInteractSound(){
        source.PlayOneShot(interactSound, 0.2f);
    }
}
