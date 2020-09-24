using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI subroutineNum, nanoInjectorNum, nanoBomberNum, quarentinerNum, virusScannerNum;
    [SerializeField] TextMeshProUGUI subroutineCostText, nanoInjectorCostText, nanoBomberCostText, quarentinerCostText, virusScannerCostText;
    void Start()
    {
        subroutineCostText.text = GameManager.i.subroutineCost.ToString();
        nanoInjectorCostText.text = GameManager.i.nanoInjectorCost.ToString();
        nanoBomberCostText.text = GameManager.i.nanoBomberCost.ToString();
        quarentinerCostText.text = GameManager.i.quarentinerCost.ToString();
        virusScannerCostText.text = GameManager.i.virusScannerCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.i.nanoPoints > GameManager.i.subroutineCost)
        {
            subroutineNum.color = Color.green;
        }
        else
        {
            subroutineNum.color = Color.red;
        }

        if (GameManager.i.nanoPoints > GameManager.i.nanoInjectorCost)
        {
            nanoInjectorNum.color = Color.green;
        }
        else
        {
            nanoInjectorNum.color = Color.red;
        }

        
        if (GameManager.i.nanoPoints > GameManager.i.nanoBomberCost)
        {
            nanoBomberNum.color = Color.green;
        }
        else
        {
            nanoBomberNum.color = Color.red;
        }

        
        if (GameManager.i.nanoPoints > GameManager.i.quarentinerCost)
        {
            quarentinerNum.color = Color.green;
        }
        else
        {
            quarentinerNum.color = Color.red;
        }

        
        if (GameManager.i.nanoPoints > GameManager.i.virusScannerCost)
        {
            virusScannerNum.color = Color.green;
        }
        else
        {
            virusScannerNum.color = Color.red;
        }
    }
}
