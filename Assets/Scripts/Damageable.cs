using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int health = 1;
    void Start()
    {
        
    }

    void Update()
    {
        if(health <= 0){
            if(gameObject.CompareTag("TrojanHorse")){
                GetComponent<TrojanHorseAbility>().SpawnBytes();
            }
            GameManager.i.nanoPoints++;
            GameManager.i.ActiveViruses.Remove(gameObject);
            AudioSource.PlayClipAtPoint(AudioManager.i.deRez, this.gameObject.transform.position);
            GameManager.i.score += health;
            Destroy(gameObject);
        }
    }
}
