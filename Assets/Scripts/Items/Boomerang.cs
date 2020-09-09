using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public Rigidbody boomerang;
    public float throwForce = 50;
    public KeyCode key;
    public KeyCode returnKey;
    public Transform target, curvePoint;
    private Vector3 oldPos;
    private bool isReturning = false;
    public bool hasFired = false;
    private float time = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (!hasFired)
        {
            if (Input.GetKeyDown(key))
            {
                Throw();
            }
        }
        if (Input.GetKeyDown(returnKey))
        {
            Return();
        }
        if (isReturning)
        {
            if(time < 1f)
            {
                boomerang.rotation = Quaternion.Slerp(boomerang.transform.rotation, target.rotation, 50*Time.deltaTime);
                boomerang.position = getBQCPoint(time, oldPos, curvePoint.position, target.position);
                time += Time.deltaTime;
            }
            else
            {
                Reset();
            }
        }
    }

    void Throw()
    {
        hasFired = true;
        isReturning = false;
        boomerang.transform.parent = null;
        boomerang.isKinematic = false;
        boomerang.AddForce(Camera.main.transform.forward * throwForce, ForceMode.Impulse);
        boomerang.AddTorque(boomerang.transform.TransformDirection(Vector3.right)*100, ForceMode.Impulse);
    }
    void Return()
    {
        time = 0f;
        hasFired = false;
        oldPos = boomerang.position;
        isReturning = true;
        boomerang.velocity = Vector3.zero;
    }

    void Reset()
    {

        boomerang.isKinematic = true;
        isReturning = false;
        boomerang.transform.parent = gameObject.transform;
        boomerang.position = target.position;
        boomerang.rotation = target.rotation;
    }

    Vector3 getBQCPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = (uu * p0) + (2 * u * t * p1) + (tt * p2);
        return p;
    }
}
