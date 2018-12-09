using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechArea : MonoBehaviour {

    public string sequenceName;

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            col.gameObject.GetComponent<ForcedSpeech>().playSequence(sequenceName);
            Destroy(gameObject);
        }
    }
}
