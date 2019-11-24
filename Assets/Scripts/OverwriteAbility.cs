using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverwriteAbility : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject self;
    [SerializeField] int max;

    public void Duplicate(){
        int chance = Random.Range(1,max);
        if(chance == 1){
            Instantiate(self,transform.position, Quaternion.identity);
        }
    }
}
