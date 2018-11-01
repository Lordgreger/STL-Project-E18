using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourWaySimpel : IntegerLogic {

    public int startingState;
    public Transform symbol;
	

    private void Start()
	{
        state = startingState;
        updateVisuals();
	}

	private void updateVisuals()
	{
        symbol.eulerAngles = new Vector3(0, 0, state * 90);
	}

    public void onInteract()
    {
        if (state > 2) {
            state = 0;
            updateVisuals();
            onChange.Invoke();
        }
        else{
            state++;
            updateVisuals();
            onChange.Invoke();
        }
    }

}
