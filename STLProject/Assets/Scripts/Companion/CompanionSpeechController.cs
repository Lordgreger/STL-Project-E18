using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionSpeechController : MonoBehaviour {

    public GameObject bubblePrefab;
    public Transform canvasPlacement;
    public LogController log;
    public CompanionInterface iface;

    public void say(string text, float lifetime) {
        SpeechBubble sb = Instantiate(bubblePrefab, canvasPlacement).GetComponent<SpeechBubble>();
        sb.setup(text, lifetime);
        log.addToLog(iface.companionName + ": " + text);
    }

}
