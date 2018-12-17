using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCreator : MonoBehaviour {

    public GameObject arrowPrefab;
    public float damage, lifetime, speed;
    public Vector3 target;

    public AudioClip fireArrowSound;
    private AudioSource source;


    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }


    public void createArrow() {
        GameObject arrow = Instantiate(arrowPrefab);
        source.PlayOneShot(fireArrowSound);
        arrow.gameObject.tag = "flyingSpear";
        arrow.transform.position = this.transform.position;
        arrow.GetComponent<Arrow>().setupArrow(target, speed, lifetime, damage);
    }

}
