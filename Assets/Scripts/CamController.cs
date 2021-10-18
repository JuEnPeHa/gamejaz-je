using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public BallController ball;
    private float offset;
    
    public GameObject plane1;
    private float offsetPlane;

    private void Start()
    {
        offset = transform.position.y - ball.transform.position.y;
        offsetPlane = transform.position.y + ball.transform.position.y;
    }

    private void Update()
    {
        Vector3 actualPos = transform.position;
        actualPos.y = ball.transform.position.y + offset;
        transform.position = actualPos;
        
        Vector3 actualPosPlane = plane1.transform.position;
        actualPosPlane.y = ball.transform.position.y - (offsetPlane/2);
        plane1.transform.position = actualPosPlane;
    }
    
}
