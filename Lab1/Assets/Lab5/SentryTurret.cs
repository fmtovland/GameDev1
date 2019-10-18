using System;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryTurret : MonoBehaviour
{
    public GameObject bullet;
    public GameObject barrel;

    public String[] beMeanTo;
    public float turnSpeed=100;
    public int bulletsPerSecond=1;

    Coroutine tracker,shooter;
    Collider tracking;

    IEnumerator track(GameObject target)
    {
        while(true)
        {
            Quaternion q = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, turnSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator shoot()
    {
        while(true)
        {
            Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
            yield return new WaitForSeconds(1/bulletsPerSecond);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(Array.Exists(beMeanTo,d=>d == other.tag))
        {
            tracking = other;
            tracker = StartCoroutine(track(other.gameObject));
            shooter = StartCoroutine(shoot());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(tracking == other)
        {
            StopCoroutine(tracker);
            StopCoroutine(shooter);
        }
    }
}
