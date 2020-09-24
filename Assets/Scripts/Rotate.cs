using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
   [SerializeField] float rotateSpeed = 50;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.up*Time.deltaTime*rotateSpeed);
    }
}
