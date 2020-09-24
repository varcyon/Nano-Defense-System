using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuarentineProjectileController : MonoBehaviour
{
    public GameObject target;
    [SerializeField] float speed;
    [SerializeField] int damage;
    public GameObject parent;

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        transform.LookAt(target.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Damageable>() != null)
        {
            Debug.Log(other.name + " Hit!");
            other.GetComponent<Damageable>().health -= damage;
            other.GetComponent<QuarentineSlowDown>().slowDown = true;
            if (other.GetComponent<OverwriteAbility>())
            {
                other.GetComponent<OverwriteAbility>().Duplicate();
            }

            Destroy(gameObject);
        }
    }
}

