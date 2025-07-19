using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private GameObject impactHole;
    [SerializeField] private ParticleSystem impactEffect;
    [SerializeField] private GameObject firePosition;
    [SerializeField] private GameObject gasTank;
    private Rigidbody[] childRigidbodies;
    private float cooldown = 1f;

    private void Awake()
    {
        childRigidbodies= gasTank.GetComponentsInChildren<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= cooldown)
        {
            cooldown = Time.time + 1f / 1;
            WeaponFire();
        }
    }

    private void WeaponFire()
    {
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }
        RaycastHit hit;
        if (Physics.Raycast(firePosition.transform.position, firePosition.transform.forward, out hit, 100))
        {
            string hitTag = hit.transform.tag;
            Debug.Log("Hit object tag: " + hitTag);
            if (hitTag== "Target")
            {
               ApplyGravity();
            }
            if (impactHole != null)
            {
                Quaternion rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                GameObject impact = Instantiate(impactHole, hit.point, rotation);
                Destroy(impact, 4f);
            }
            if (impactEffect != null)
            {
                  impactEffect.transform.position = hit.point;
                  impactEffect.transform.rotation = Quaternion.LookRotation(Vector3.up,hit.normal);
                  impactEffect.Play();
            }
        }
    }

    private void ApplyGravity()
    {
        if (childRigidbodies[1].useGravity==false)
        {
            foreach (Rigidbody rb in childRigidbodies)
            {
                rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                rb.interpolation = RigidbodyInterpolation.Interpolate;
                rb.useGravity = true;
                //explosion.transform.position = 
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
