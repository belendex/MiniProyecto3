using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    private float minDistance = .5f;
    private float maxDistance = 3f;
    private float suavidad = 20f;
    private float distancia;

    Vector3 direction;

    private void Start()
    {
        direction = transform.localPosition.normalized;
        distancia = transform.localPosition.magnitude;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 posCamera = transform.parent.TransformPoint(direction * maxDistance);

        RaycastHit hit;
        if(Physics.Linecast(transform.parent.position, posCamera, out hit))
        {
            distancia = Math.Clamp(hit.distance * 0.05f, minDistance, maxDistance);
        }
        else
        {
            distancia = maxDistance;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, direction * distancia, suavidad * Time.deltaTime);
    }
}
