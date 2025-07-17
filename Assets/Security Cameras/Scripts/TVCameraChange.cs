using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TVCameraChange : MonoBehaviour
{
    [SerializeField] private MeshRenderer tvMeshRenderer_1;
    [SerializeField] private MeshRenderer tvMeshRenderer_2;
    [SerializeField] private MeshRenderer tvMeshRenderer_3;
    [SerializeField]private Material screen_Off;
    [SerializeField] private Material screen_1;
    [SerializeField] private Material screen_2;
    [SerializeField] private Material screen_3;
    [SerializeField] private GameObject trigger;
    [SerializeField] private GameObject canvasObject;
    private Boolean canvasObjectState = false;
    private Boolean buttonState = false;

    private void Awake()
    {
        tvMeshRenderer_1.material = screen_Off;
        tvMeshRenderer_2.material = screen_Off;
        tvMeshRenderer_3.material = screen_Off;
        canvasObject.SetActive(false);
    }

    public void ChangeScreen()
    {
        if (buttonState == false)
        {
            tvMeshRenderer_1.material = screen_1;
            tvMeshRenderer_2.material = screen_2;
            tvMeshRenderer_3.material = screen_3;
            buttonState = true;
        }
        else
        {
            tvMeshRenderer_1.material = screen_Off;
            tvMeshRenderer_2.material = screen_Off;
            tvMeshRenderer_3.material = screen_Off;
            buttonState = false;
        }
    }

    public void InteractibleSetActive()
    {
        if (canvasObjectState==false)
        {
            canvasObject.SetActive(true);
            canvasObjectState = true;
        }
        else
        {
            canvasObject.SetActive(false);
            canvasObjectState = false;
        }
    }
}
