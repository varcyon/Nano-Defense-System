using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementCost : MonoBehaviour
{
    public int cost;
    public bool active = false;

    void Start()
    {
        switch (gameObject.tag)
        {
            case "Subroutine":
            cost = GameManager.i.subroutineCost;
            break;

            case "NanoInjector":
            cost = GameManager.i.nanoInjectorCost;
            break;

            case "NanoBomber":
            cost = GameManager.i.nanoBomberCost;
            break;

            case "Quarentiner":
            cost = GameManager.i.quarentinerCost;
            break;

            case "VirusScanner":
            cost = GameManager.i.virusScannerCost;
            break;

            default:
            break;
        }
    }
}
