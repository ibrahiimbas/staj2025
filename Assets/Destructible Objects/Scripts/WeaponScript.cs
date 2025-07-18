using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private GameObject firePosition;
    private float cooldown = 1f;


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
            // Etki efekti
            if (impactEffect != null)
            {
                GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impact, 2f);
            }
        }
    }
}
