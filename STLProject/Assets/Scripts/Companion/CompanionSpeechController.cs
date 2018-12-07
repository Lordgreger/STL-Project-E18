using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionSpeechController : MonoBehaviour {

    public GameObject bubblePrefab;
    public Transform canvasPlacement;
    public LogController log;
    public CompanionInterface iface;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            say("OMG HELLO!", 2f);
        }
    }

    public void say(string text, float lifetime) {
        Instantiate(bubblePrefab, canvasPlacement).GetComponent<SpeechBubble>().setup(text, lifetime);
        log.addToLog(iface.companionName + ": " + text);
    }

}
