using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooleanLogic : ILogic {
    protected bool state;

    public virtual bool getState() { return state; }
    public virtual void setState(bool i) { state = i; }
}
