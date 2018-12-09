using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SpeechBubble : MonoBehaviour {

    public TextMeshProUGUI tm;
    public RectTransform rect;

	public void setup(string text, float lifetime) {
        tm.text = text;
        tm.ForceMeshUpdate();

        tm.rectTransform.sizeDelta = new Vector2(tm.rectTransform.sizeDelta.x, tm.renderedHeight + 2 * tm.margin.y);
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, tm.rectTransform.sizeDelta.y);
        rect.ForceUpdateRectTransforms();

        Destroy(gameObject, lifetime);
    }

    private void Update() {
        //fixSize();
    }

    private void fixSize() {
        if (tm.isTextOverflowing) {
            Vector2 size = tm.rectTransform.sizeDelta;
            tm.rectTransform.sizeDelta = new Vector2(size.x, size.y + tm.fontSize);
            rect.sizeDelta = tm.rectTransform.sizeDelta;
        }
    }
}
