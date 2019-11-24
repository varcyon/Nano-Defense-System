using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseDamager : MonoBehaviour
{
    [SerializeField] int damage = 2;

    void OnTriggerEnter(Collider other)
    {
        if (GetComponentInParent<PlacementCost>().active)
        {
            other.GetComponent<Damageable>().health -= damage;
            if (other.GetComponent<OverwriteAbility>())
            {
                other.GetComponent<OverwriteAbility>().Duplicate();
            }


        }

    }
}
