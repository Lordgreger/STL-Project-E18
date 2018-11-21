using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpController : MonoBehaviour {

    public Animation ani;

	void Start () {
        Destroy(gameObject, ani.clip.length);
	}

    public void setText(string text) {
        GetComponent<TextMeshProUGUI>().SetText(text);
    }
    
}
