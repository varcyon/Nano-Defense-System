using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NanoBlockController : MonoBehaviour
{
   MeshRenderer r;
   public bool buildable = true;
    void Start() {
        r = GetComponent<MeshRenderer>();
   }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position,Vector3.up, 1f)){
            buildable = false;
        }
         r.material.SetColor("_BaseColor",Color.white);
    }
}
