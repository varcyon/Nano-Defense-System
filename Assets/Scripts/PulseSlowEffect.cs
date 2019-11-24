using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PulseSlowEffect : MonoBehaviour
{
    [SerializeField] int slowSpeed = 2;
    void OnTriggerEnter(Collider other)
    {
         
        if (GetComponentInParent<PlacementCost>().active)
        {
           float Speed = other.GetComponent<NavMeshAgent>().speed;
            other.GetComponent<NavMeshAgent>().speed = Speed / slowSpeed;
        }

       
    }

    void OnTriggerExit(Collider other)
    {
        if (GetComponentInParent<PlacementCost>().active)
        {
           float Speed = other.GetComponent<NavMeshAgent>().speed;
            other.GetComponent<NavMeshAgent>().speed = Speed * slowSpeed;
        }

    }
}
