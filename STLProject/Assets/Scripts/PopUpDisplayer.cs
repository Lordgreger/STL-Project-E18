using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpDisplayer : MonoBehaviour {

    public Canvas canvas;
    public GameObject popUpPrefab;

    public void spawnText(string text) {
        Instantiate<GameObject>(popUpPrefab, canvas.transform).GetComponent<PopUpController>().setText(text);
    }
}
