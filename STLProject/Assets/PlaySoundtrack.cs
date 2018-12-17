using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundtrack : MonoBehaviour {

    public AudioClip[] tracks;
    private AudioSource source;


    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        if(!source.isPlaying){
            source.PlayOneShot(tracks[Random.Range(0, tracks.Length)]);
        }
	}
}
