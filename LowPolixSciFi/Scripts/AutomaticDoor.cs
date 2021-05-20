using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour {


    Animator doorAnimator;
    public GameObject player;

	// Use this for initialization
	void Start () {
        doorAnimator = GetComponent<Animator>();
	}

    // Update is called once per frame]
    float distanceToPlayer;
    public float MinDistanceToOpen;
    bool doorOpened;
	void Update () {
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if(distanceToPlayer <= MinDistanceToOpen)
        {
            if (!doorOpened)
            {
                doorOpened = true;
                doorAnimator.SetTrigger("Open");
            }
        }
        else
        {
            if (doorOpened)
            {
                doorOpened = false;
                doorAnimator.SetTrigger("Close");
            }
        }
	}
}
