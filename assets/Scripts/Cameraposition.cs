using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraposition : MonoBehaviour
{

    public float smoothSpeed = 0.5f;
    public Transform player;
    public Vector3 offset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 DesiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, DesiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

    }

}
