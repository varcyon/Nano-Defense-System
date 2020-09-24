using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NanoBlockController : MonoBehaviour
{
   MeshRenderer r;
   public bool buildable = true;
   public bool activeBlock = false;
    void Start() {
        r = GetComponent<MeshRenderer>();
   }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position,Vector3.up, 1f)){
            buildable = false;
        }
        if(!activeBlock){
        r. material = GameManager.i.NormalBlock;
        }
    }
}
