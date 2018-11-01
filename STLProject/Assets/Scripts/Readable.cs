using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Readable : MonoBehaviour {
    public GameObject hintCanvas;


    
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            hintCanvas.SetActive(false);
        }
    }

    public void toggleText()
    {
        hintCanvas.SetActive(!hintCanvas.activeSelf);
    }
}
