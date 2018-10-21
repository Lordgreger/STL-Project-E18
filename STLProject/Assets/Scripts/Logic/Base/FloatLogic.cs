using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatLogic : MonoBehaviour {
    protected float state;

    public virtual float getState() { return state; }
    public virtual void setState(float i) { state = i; }
}
