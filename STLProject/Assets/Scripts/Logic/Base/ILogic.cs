using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ILogic : MonoBehaviour {

    [HideInInspector]
    public UnityEvent onChange = new UnityEvent();
}
