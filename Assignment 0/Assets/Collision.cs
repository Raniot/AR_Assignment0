using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var meteorTarget = transform.Find("MeteorTarget");
        var meteor = meteorTarget.Find("Meteor");

        var sunTarget = transform.Find("SunTarget");
        var sun = sunTarget.Find("Sun");
        var earth = sun.Find("Earth");

        var collisionDistance = meteor.lossyScale + earth.lossyScale;

        if(
            Math.Abs(earth.position.x - meteor.position.x) < collisionDistance.x &&
            Math.Abs(earth.position.y - meteor.position.y) < collisionDistance.y &&
            Math.Abs(earth.position.z - meteor.position.z) < collisionDistance.z
        )
        {
            Debug.Log("Collision!!!");
            Explode(meteor);
        }
    }

    void Explode(Transform trans)
    {
        var explosion = trans.GetComponent<ParticleSystem>();
        explosion.Play();
    }
}
