using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class QuarentineSlowDown : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public int slowDownAmnt;
    public float slowDownTime;
    float slowTimer;
    public bool slowDown;
     bool endSlowDown;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (slowDown)
        {
            navMeshAgent.speed = navMeshAgent.speed / slowDownAmnt;
            slowDown = false;
            endSlowDown = true;
        }

        if (endSlowDown)
        {
            slowTimer += Time.deltaTime;
            if (slowTimer > slowDownTime)
            {
                navMeshAgent.speed = navMeshAgent.speed * slowDownAmnt;
                slowTimer = 0;
                endSlowDown = false;
            }
        }
    }
}
