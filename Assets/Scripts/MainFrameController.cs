using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFrameController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        GameManager.MainFrameHealth--;
        Destroy(other.gameObject);
    }
}
