using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusScannerController : MonoBehaviour
{
    [SerializeField] float pulseRate;
    [SerializeField] GameObject attackAreaDisplay;
    [SerializeField] GameObject pulseArea;
    [SerializeField] Animator pulse;
    [SerializeField] GameObject slowArea;

    [SerializeField] Animator animator;

    private void Awake()
    {
        animator.enabled = false;
        slowArea.SetActive(false);

    }
    void Update()
    {
        if (GetComponent<PlacementCost>().active)
        {
            attackAreaDisplay.SetActive(false);
            slowArea.SetActive(true);
            animator.enabled = true;
        }
    }

    void Start()
    {
        pulse.speed = pulseRate;
    }
}
