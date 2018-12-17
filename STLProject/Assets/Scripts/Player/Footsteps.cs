using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour {

    [SerializeField]

    private AudioClip[] footsteps;
    private AudioSource source;


    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Footstep(){
        source.PlayOneShot(footsteps[Random.Range(0, footsteps.Length)], Random.Range(0.05F,0.1F));
    }
}
