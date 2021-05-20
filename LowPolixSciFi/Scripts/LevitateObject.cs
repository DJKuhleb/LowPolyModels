using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitateObject : MonoBehaviour {

	

    Vector3 posOffset;
    Vector3 tempPos;

    bool inTrigger;
    

    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;   
        levitatingObject = other.transform.gameObject;
        if (levitatingObject.GetComponent<CharacterController>())
            controller = levitatingObject.GetComponent<CharacterController>();
    }

    private void OnTriggerStay(Collider other)
    {
        inTrigger = true;       
        levitatingObject = other.transform.gameObject;
        if (levitatingObject.GetComponent<CharacterController>())
            controller = levitatingObject.GetComponent<CharacterController>();
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
        levitatingObject = null;
        controller = null;       
    }


    GameObject levitatingObject;
    CharacterController controller;
    float levitationGravity = 3.0f;
    public float LevitationFraction = 0.15f;

    // Update is called once per frame
    Vector3 vel;
    bool pause;
    void Update()
    {


        if (inTrigger)
        {
            if (levitatingObject)
                if (controller)
                {                   
                   vel = Vector3.Lerp(transform.up * LevitationFraction, transform.up, Time.deltaTime);
                   controller.Move(vel);                   
                }
        }

    }
}
