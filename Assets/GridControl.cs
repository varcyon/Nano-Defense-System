using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridControl : MonoBehaviour
{
   public MeshRenderer renderer;
   public Material mat;
   public Color color;
   public float intensity;
   float maxIntensity =4f;
   float minIntensity = 0f;
   bool brightening = true;
   public float changeSpeed = 1;
   // public static int emissionStr = Shader.PropertyToID("Emissive Intensity");

     void Start() {
        intensity = minIntensity;
    }
    void Update()
    {
       if(intensity > maxIntensity){
          brightening = false;
       } else if(intensity < minIntensity){
          brightening = true;
       }

       if(brightening){
          intensity += Time.deltaTime * changeSpeed;
       } else {
          intensity -= Time.deltaTime * changeSpeed;
       }
       
        mat.SetColor("_EmissiveColor",color * intensity);
        renderer.material = mat;
    }
}
