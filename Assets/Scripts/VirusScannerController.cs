using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusScannerController : MonoBehaviour
{
    [SerializeField] float pulseRate;
    [SerializeField] GameObject attackAreaDisplay;
    [SerializeField] GameObject pulseArea;
    [SerializeField] Animator pulse;

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PlacementCost>().active)
        {
            attackAreaDisplay.SetActive(false);
        }
    }

    void Start()
    {
        pulse.speed = pulseRate;
    }
}
