using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detach : MonoBehaviour
{
    [SerializeField] GameObject explosion;
     void OnEnable() {
        
    
    
        Instantiate(explosion,transform.position,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
