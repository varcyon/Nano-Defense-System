using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntivirusePlacement : MonoBehaviour
{
    [SerializeField] GameObject subroutine;
    [SerializeField] GameObject nanoInjector;
    [SerializeField] GameObject nanoBomber;
    [SerializeField] GameObject quarentiner;
    [SerializeField] GameObject virusScanner;
    bool placing;
    GameObject currentAntivirus;
    void Start()
    {

    }

    void Update()
    {

        ///// creates Anti-Virus in the world
        /// Places Subroutine
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (currentAntivirus != null)
            {
                Destroy(currentAntivirus);
            }
            if (GameManager.i.nanoPoints >= subroutine.GetComponent<PlacementCost>().cost)
            {
                currentAntivirus = Instantiate(subroutine, GameManager.activeBlock.transform.position, Quaternion.identity);
                currentAntivirus.GetComponent<PlacementCost>().active = false;
                placing = true;
            }
            else
            {
                Debug.Log("You don't have enough Nano Points to make this.");
            }
        }
        /// Places Nano-Injector
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (currentAntivirus != null)
            {
                Destroy(currentAntivirus);
            }
            if (GameManager.i.nanoPoints >= nanoInjector.GetComponent<PlacementCost>().cost)
            {
                currentAntivirus = Instantiate(nanoInjector, GameManager.activeBlock.transform.position, Quaternion.identity);
                currentAntivirus.GetComponent<PlacementCost>().active = false;
                placing = true;
            }
            else
            {
                Debug.Log("You don't have enough Nano Points to make this.");
            }
        }

        /// Places Nano-Bomber
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (currentAntivirus != null)
            {
                Destroy(currentAntivirus);
            }
            if (GameManager.i.nanoPoints >= nanoBomber.GetComponent<PlacementCost>().cost)
            {
                currentAntivirus = Instantiate(nanoBomber, GameManager.activeBlock.transform.position, Quaternion.identity);
                currentAntivirus.GetComponent<PlacementCost>().active = false;
                placing = true;
            }
            else
            {
                Debug.Log("You don't have enough Nano Points to make this.");
            }
        }

        /// Places Quarentiner
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (currentAntivirus != null)
            {
                Destroy(currentAntivirus);
            }
            if (GameManager.i.nanoPoints >= quarentiner.GetComponent<PlacementCost>().cost)
            {
                currentAntivirus = Instantiate(quarentiner, GameManager.activeBlock.transform.position, Quaternion.identity);
                currentAntivirus.GetComponent<PlacementCost>().active = false;
                placing = true;
            }
            else
            {
                Debug.Log("You don't have enough Nano Points to make this.");
            }
        }

        /// Places Virus Scanner
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (currentAntivirus != null)
            {
                Destroy(currentAntivirus);
            }
            if (GameManager.i.nanoPoints >= virusScanner.GetComponent<PlacementCost>().cost)
            {
                currentAntivirus = Instantiate(virusScanner, GameManager.activeBlock.transform.position, Quaternion.identity);
                currentAntivirus.GetComponent<PlacementCost>().active = false;
                placing = true;
            }
            else
            {
                Debug.Log("You don't have enough Nano Points to make this.");
            }
        }

        ///// keeps Anti-Virus at mouse 
        if (currentAntivirus != null && placing)
        {
            Vector3 pos = GameManager.activeBlock.transform.position;
            currentAntivirus.transform.position = pos;
            if (Input.GetMouseButtonDown(1))
            {
                currentAntivirus.transform.Rotate(0, 90, 0);
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (GameManager.activeBlock.GetComponent<NanoBlockController>().buildable)
                {
                    GameManager.i.nanoPoints -= currentAntivirus.GetComponent<PlacementCost>().cost;
                    GameObject go = Instantiate(currentAntivirus, pos, currentAntivirus.transform.rotation);
                    go.GetComponent<PlacementCost>().active = true;
                    Destroy(currentAntivirus);
                    placing = false;
                }
            }
        }
    }
}
