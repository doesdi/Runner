using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn2 : MonoBehaviour
{
    public Transform SpawnPos;
    public GameObject Enemy;
    public float time;
    void Start()
    {
        StartCoroutine(SpawnEnemy1());
    }

    void Repeat()
    {
        StartCoroutine(SpawnEnemy1());
    }

    IEnumerator SpawnEnemy1()
    {
        yield return new WaitForSeconds(time);
        var newObj = (GameObject)Instantiate(Enemy, SpawnPos.position, Quaternion.identity);
        Destroy(newObj, time + 100);

        Repeat();
    }
}
