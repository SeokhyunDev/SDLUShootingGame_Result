using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemy = null;
    [SerializeField] float spawnDuration = 0f;
    private void Start()
    {
        StartCoroutine(EnemySpawn());
    }
    IEnumerator EnemySpawn()
    {
        yield return new WaitForSeconds(3f);
        while(true)
        {
            Instantiate(enemy, new Vector3(9.5f, Random.Range(-4, 4.5f), 0), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
