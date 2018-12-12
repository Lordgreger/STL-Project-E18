using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearSpitterActivateable : ArrowCreator {
    public List<Vector2> dirs;

    public void onActivate() {
        foreach (var d in dirs) {
            target = new Vector3(d.x, d.y) + transform.position;
            createArrow();
        }
    }
}
