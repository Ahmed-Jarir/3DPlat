using System;
using System.Collections;
using UnityEngine;

public class CurvedProjectile : MonoBehaviour
{
    public float projectileInitSpeed = 3.0f;

    private Vector3 initPos;
    private float grav = 9.81f;
    private float newPosition;
    private float time = 0f;
    private float angle;

    private void Start()
    {
        initPos = transform.position;
    }

    private void Update()
    {
        angle = transform.eulerAngles.y;
        angle *= Mathf.Deg2Rad;
        MoveObj();
    }


    private void MoveObj()
    {
        time += Time.deltaTime;
        float x = (projectileInitSpeed * time * Mathf.Sin(angle));
        float y = projectileInitSpeed * time * Mathf.Cos(angle) - 0.5f * - Physics.gravity.y * Mathf.Pow(time,2);
        transform.position = initPos + Vector3.up*y + transform.forward*x;
    }
}