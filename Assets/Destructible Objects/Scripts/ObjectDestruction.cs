using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestruction : MonoBehaviour
{
    [SerializeField] private GameObject gasTank;
    [SerializeField] private ParticleSystem explosion;
    private Rigidbody[] childRigidbodies;

    private void Awake()
    {
        childRigidbodies= gasTank.GetComponentsInChildren<Rigidbody>();
    }
    public void ApplyGravity()
    {
        if (childRigidbodies[0].useGravity==false)
        {
            foreach (Rigidbody rb in childRigidbodies)
            {
                rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                rb.interpolation = RigidbodyInterpolation.Interpolate;
                rb.useGravity = true;
                explosion.transform.position = gasTank.transform.position;
                explosion.Play();   
                rb.AddExplosionForce(100f, gasTank.transform.position,25f);
                Destroy(gasTank,5f);
            }
        }
        else
        {
            foreach (Rigidbody rb in childRigidbodies)
            {
                rb.AddExplosionForce(15f, gasTank.transform.position,5f);
            }
        }
    }
}
