using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform SpawnPos;
    public GameObject Enemy;
    public float time;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void Repeat()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(time);
        var newObj = (GameObject) Instantiate(Enemy, SpawnPos.position, Quaternion.identity);     
        Destroy(newObj, time+20);
           
        Repeat();
    }
}
