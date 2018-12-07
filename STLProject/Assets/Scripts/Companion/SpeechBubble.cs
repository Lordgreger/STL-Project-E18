using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeechBubble : MonoBehaviour {

    public TextMeshProUGUI tm;

	public void setup(string text, float lifetime) {
        tm.text = text;
        Destroy(gameObject, lifetime);
    }
}
