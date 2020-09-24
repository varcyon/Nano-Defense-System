using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{
    [SerializeField] GameObject virus;
    [SerializeField] float spawnRate;
    [SerializeField] float spawnRateMin;
    [SerializeField] float spawnRateMax;
   [HideInInspector] public float spawnTimer;
  [HideInInspector]  public float timer;
    void Start()
    {
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        spawnTimer = spawnRate;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (GameManager.i.virusesStart)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        int chance = Random.Range(1, 6);
        if (timer >= spawnTimer)
        {
            if (GameManager.i.virusPoints > virus.GetComponent<Damageable>().health)
            {
                timer = 0;
                if (chance <= 3)
                {
                    GameObject go = Instantiate(virus, GameManager.i.StartPosA.transform.position, Quaternion.identity);
                    GameManager.i.ActiveViruses.Add(go);
                    GameManager.i.virusPoints -= virus.GetComponent<Damageable>().health;
                }
                if (chance >= 4)
                {
                    GameObject go = Instantiate(virus, GameManager.i.StartPosB.transform.position, Quaternion.identity);
                    GameManager.i.ActiveViruses.Add(go);
                    GameManager.i.virusPoints -= virus.GetComponent<Damageable>().health;
                }
            }
        }
    }
}
