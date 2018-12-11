using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleInventory : MonoBehaviour {

    public string inventory;
    public List<GameObject> riddleTablets = new List<GameObject>();
    public int correctTablets = 0;
    private RiddleInsert insertTest;
	private void Start()
	{
        insertTest = GameObject.FindGameObjectWithTag("Placeholders").GetComponent<RiddleInsert>();
	}

	public void StoreName(string info)
    {
        inventory = info;
        Debug.Log("called function");
    }

	private void Update()
	{
        if (correctTablets == 4){
            Destroy(GameObject.FindWithTag("door"));
        }

	}
}
