using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByteSpawner : MonoBehaviour
{
    [SerializeField] GameObject virus;
    [SerializeField] float spawnRate = 2f;
    public float spawnTimer;
    public float timer;
    void Start()
    {
        spawnTimer = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Spawn();
    }

    void Spawn()
    {
        if (timer >= spawnTimer)
        {
            timer = 0;
            Instantiate(virus, GameManager.StartPos.transform.position, Quaternion.identity);
        }
    }
}
