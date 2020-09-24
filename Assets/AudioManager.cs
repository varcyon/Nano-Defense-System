using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip deRez;
    public static AudioManager i;

     void Awake() {
        if(i != this){
            i = this;
        }
    }
}
