using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BooleanLogicCombiner : MonoBehaviour {

    public List<BooleanLogic> bools = new List<BooleanLogic>();
    public UnityEvent change;

    private void Start() {
        foreach (var b in bools) {
            b.onChange.AddListener(onChange);
        }
    }

    public void onChange() {
        foreach (var b in bools) {
            if (!b.getState()) {
                return;
            }
        }
        change.Invoke();
    }
}
