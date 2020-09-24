using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFrameController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        GameManager.i.MainFrameHealth -= other.GetComponent<Damager>().damage;
        GameManager.i.ActiveViruses.Remove(other.gameObject);
        Destroy(other.gameObject);
    }
}
