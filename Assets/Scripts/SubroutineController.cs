using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubroutineController : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject firePoint;
    [SerializeField] float fireRate;
    [SerializeField] GameObject attackAreaDisplay;
    float timer;
    public List<GameObject> targets = new List<GameObject>();
    void OnTriggerEnter(Collider other)
    {
        targets.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        targets.Remove(other.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < targets.Count; i++)
        {
            if(targets[i]== null){
                targets.RemoveAt(i);
            }
        }
        if(GetComponent<PlacementCost>().active){
            attackAreaDisplay.SetActive(false);
        }
        timer += Time.deltaTime;
        Fire();
    }

    void Fire()
    {
        if (GetComponent<PlacementCost>().active && targets.Count > 0)
        {
            if (timer > fireRate)
            {
                timer = 0;
                GameObject go = Instantiate(projectile, firePoint.transform.position, Quaternion.identity);
                go.GetComponent<SubroutineProjectileController>().parent = gameObject;
                go.GetComponent<SubroutineProjectileController>().target = targets[0];
            }
        }

    }
}
