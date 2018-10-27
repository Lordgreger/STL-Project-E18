using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedBooleanLogic : BooleanLogic {


    public bool stableState;
    public float relapseTime;

    //[HideInInspector]
    public float timer;
    //[HideInInspector]
    public bool timerPaused;

    private void Start() {
        state = stableState;
    }

    private void Update() {
        if (!timerPaused) {
            if (!stableState == state) {
                if (timer != 0.0f) {
                    timer -= Time.deltaTime;
                    if (timer < 0.0f) {
                        setState(stableState);
                        onTimerDone();
                    }
                }
            }
        }
    }

    public override void setState(bool i) {
        if (state == stableState) {
            if (i == state) { // From stable to stable
                // Do nothing
            }
            else { // From stable to unstable
                state = !stableState;
                timer = relapseTime;
                onChange.Invoke();
            }
        }
        else {
            if (i == state) { // From unstable to unstable
                timer = relapseTime; // reset timer
            }
            else { // From unstable to stable
                state = stableState;
                timer = 0.0f;
                onChange.Invoke();
            }
        }
    }

    protected virtual void onTimerDone() {

    }
}
