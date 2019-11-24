using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NanoBombController : MonoBehaviour
{
    public GameObject target;
    [SerializeField] float speed;
    public GameObject parent;
    [SerializeField] GameObject AOE;
    bool exploded = false;

    private void Start()
    {


        transform.LookAt(target.transform.position);
    }
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        if (!exploded)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Damageable>() != null)
        {
            Debug.Log(other.name + " Hit!");
            AOE.SetActive(true);
            exploded = true;
            Destroy(gameObject, 0.1f);
        }
    }
}

