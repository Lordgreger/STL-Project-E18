using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntegerLogic : ILogic {
    protected int state;

    public virtual int getState() { return state; }
    public virtual void setState(int i) { state = i; }
}
