using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        GameManager.singleton.AddScore(15);
        GameManager.singleton.NextLevel();
    }
}
