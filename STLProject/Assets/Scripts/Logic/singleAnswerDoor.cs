using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleAnswerDoor : MonoBehaviour {

    public Sprite open;
    public Sprite closed;

    public SpriteRenderer rend;

    public Collider2D doorCollider;

    public List<BooleanLogic> offLevers = new List<BooleanLogic>();
    public BooleanLogic onLever;

    private void Start()
    {
        foreach(BooleanLogic l in offLevers){
            l.onChange.AddListener(checkSolution);
        }
        onLever.onChange.AddListener(checkSolution);
    }

    void checkSolution(){
        if(onLever.getState()) {
            foreach (BooleanLogic l in offLevers)
            {
                if(l.getState()){
                    rend.sprite = closed;
                    doorCollider.enabled = true;
                    return;
                }
            }
            rend.sprite = open;
            doorCollider.enabled = false;
        } else {
            rend.sprite = closed;
            doorCollider.enabled = true;
        }
    }

}
