using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private GameObject trigger;
    [SerializeField] private TVCameraChange cameraChange;
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask mask;

    private RaycastHit raycastHit;
    private Boolean inTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        cameraChange.InteractibleSetActive();
        inTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        cameraChange.InteractibleSetActive();
        inTrigger = false;
    }

    private void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 750f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position,             
            Color.green);

        if (Input.GetMouseButtonDown(0) && inTrigger)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit,100,mask))
            {
                Debug.Log(hit.transform.name);
                cameraChange.ChangeScreen();
            }
        }
    }
}
