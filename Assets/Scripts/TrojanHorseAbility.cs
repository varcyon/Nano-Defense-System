using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrojanHorseAbility : MonoBehaviour
{
    [SerializeField] GameObject Byte;
    [SerializeField] int minSpawn;
    [SerializeField] int maxSpawn;
    
   public void SpawnBytes(){
        int count = Random.Range(minSpawn,maxSpawn);
        for (int i = 0; i < count; i++)
        {
            Instantiate(Byte,transform.position, Quaternion.identity);
        }
    }
}
