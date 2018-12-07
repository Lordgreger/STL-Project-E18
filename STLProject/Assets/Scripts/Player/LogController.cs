using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LogController : MonoBehaviour {

    public TextMeshProUGUI tm;

    private void Start() {
        tm.text = "<Start of Log>";
    }

    private void Update() {
        fixSize();
    }

    private void fixSize() {
        if (tm.isTextOverflowing) {
            Vector2 size = tm.rectTransform.sizeDelta;
            tm.rectTransform.sizeDelta = new Vector2(size.x, size.y + 2f);
        }
    }

    public void addToLog(string text) {
        tm.text += "\n" + text;
        Vector2 size = tm.rectTransform.sizeDelta;
        tm.rectTransform.sizeDelta = new Vector2(size.x, size.y + tm.fontSize);
    }
}
