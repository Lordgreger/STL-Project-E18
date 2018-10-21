using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringLogic : MonoBehaviour {
    protected string state;

    public virtual string getState() { return state; }
    public virtual void setState(string i) { state = i; }
}
