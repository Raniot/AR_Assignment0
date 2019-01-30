using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var sunTarget = transform.Find("SunTarget");
        var sun = sunTarget.Find("Sun");
        var earth = sun.Find("Earth");
        var earthLossyScale = earth.lossyScale;
        var earthPosition = earth.position;

        var meteorTarget = transform.Find("MeteorTarget");
        var meteor = meteorTarget.Find("Meteor");
        var meteorLossyScale = meteor.lossyScale;
        var meteorPosition = meteor.position;

        var totalDistance = earthLossyScale + meteorLossyScale;
        var fuseTime = 0.5F;
        if (
            Math.Abs(earthPosition.x - meteorPosition.x) < (totalDistance.x) &&
            Math.Abs(earthPosition.y - meteorPosition.y) < (totalDistance.y) &&
            Math.Abs(earthPosition.z - meteorPosition.z) < (totalDistance.z)
        )
        {
            Debug.Log("Collide!!!!!");
            Explode(meteor);
        }
    }

    void Explode(Transform transform)
    {
        var exp = transform.Find("Explosion").GetComponent<ParticleSystem>();
        exp.Play();
        //Destroy(transform, exp.main.duration);
    }
}
