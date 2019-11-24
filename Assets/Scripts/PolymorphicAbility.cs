using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolymorphicAbility : MonoBehaviour
{
    [SerializeField] float chanceTime;
    [SerializeField] float teleportDistance;
    float timer;
 
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > chanceTime)
        {
            int chance = Random.Range(1, 5);
            if (chance == 1)
            {
            Debug.Log("Teleporting!");
                transform.position += transform.forward * teleportDistance;
            }
            timer = 0;
        }
    }
}
