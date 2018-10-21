using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SetSpriteLayerToPosition : MonoBehaviour {

    public SpriteRenderer rend;
    public int resolutionScale;
    public bool useOffset;
    public float offset;

    private void Start() {
        if (useOffset) {
            rend.sortingOrder = -Mathf.CeilToInt(((transform.position.y * resolutionScale) - offset));
        }
        else {
            rend.sortingOrder = -Mathf.CeilToInt((transform.position.y * resolutionScale));
        }
    }

}
