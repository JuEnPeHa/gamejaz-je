using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    public float impulseForce = 3f;
    private bool ignoreNextCollision;
    private Vector3 startPosition;
    public GameObject helix;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        helix = GameObject.FindWithTag("Helix");
    }

    private void OnCollisionEnter(Collision other)
    {

        if (ignoreNextCollision)
        {
            return;
        }
        DeathPart deathPart = other.transform.GetComponent<DeathPart>();
        if (deathPart)
        {
            GameManager.singleton.RestartLevel();
        }
        
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up*impulseForce,ForceMode.Impulse);
        ignoreNextCollision = true;
        //GameManager.singleton.AddScore(1);
        
        Invoke("AllowNextCollision",0.1f);
    }

    private void AllowNextCollision()
    {
        ignoreNextCollision = false;
    }

    public void ResetBall()
    {
        transform.position = startPosition;
        /*helix.transform.localEulerAngles = HelixController.startRotation;*/

    }
}
