using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDamager : MonoBehaviour
{
    public int damage =1;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Virus")){
            Debug.Log("Virus hit with AOE");
        other.GetComponent<Damageable>().health -= damage;
        if(other.GetComponent<OverwriteAbility>()){
            other.GetComponent<OverwriteAbility>().Duplicate();
        }
        }
    }
}
