using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TVCameraChange : MonoBehaviour
{
    public MeshRenderer tvMeshRenderer;
    public Material screen_Off;
    public Material screen_1;
    public Material screen_2;
    public Material screen_3;
    [SerializeField] private GameObject trigger;

    private void Awake()
    {
        tvMeshRenderer.material = screen_Off;
    }
}
