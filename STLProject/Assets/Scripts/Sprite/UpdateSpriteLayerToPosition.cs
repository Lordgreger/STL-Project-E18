using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSpriteLayerToPosition : MonoBehaviour {

    public SpriteRenderer rend;
    public int resolutionScale;
    public bool useOffset;
    public float offset;

    void Update () {
        if (useOffset) {
            rend.sortingOrder = -Mathf.CeilToInt(((transform.position.y * resolutionScale) - offset));
        }
        else {
            rend.sortingOrder = -Mathf.CeilToInt((transform.position.y * resolutionScale));
        }
    }
}
