using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<Transform> spawnPoints;
    private int index = 0;
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1f);
        while (index < 5)
        {
            Instantiate(enemyPrefab, spawnPoints[index].position, 
                quaternion.identity, spawnPoints[index].gameObject.transform);
            yield return new WaitForSeconds(2f);
            index++;
        }
    }
}
