using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntivirusePlacement : MonoBehaviour
{
    [SerializeField] GameObject subroutine;
bool placing;
    GameObject currentAntivirus;
    void Start()
    {

    }

    void Update()
    {

        ///// creates Anti-Virus in the world
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentAntivirus = Instantiate(subroutine, GameManager.activeBlock.transform.position, Quaternion.identity);
            placing = true;
        }

        ///// keeps Anti-Virus at mouse 
        if (currentAntivirus != null && placing)
        {
            Vector3 pos = new Vector3(GameManager.activeBlock.transform.position.x, GameManager.activeBlock.transform.position.y - 0.25f, GameManager.activeBlock.transform.position.z);
            currentAntivirus.transform.position = pos;
            if(Input.GetMouseButtonDown(1)){
                currentAntivirus.transform.Rotate(0,90,0); 
            }
            if(Input.GetMouseButtonDown(0)){
                if(GameManager.activeBlock.GetComponent<NanoBlockController>().buildable){
                Instantiate(currentAntivirus,pos,currentAntivirus.transform.rotation);
                Destroy(currentAntivirus);
                placing = false;
                }
            }
        }
    }
}
