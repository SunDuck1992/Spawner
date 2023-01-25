using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform[] _pointsOfSpawn;
    [SerializeField] float _secondsBetweenSpawn;

    private void Start()
    {
       StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var waitForSeconds = new WaitForSeconds(_secondsBetweenSpawn);

        foreach (var spawnPoint in _pointsOfSpawn)
        {
            Instantiate(_enemy, spawnPoint.transform.position, Quaternion.identity);
            yield return waitForSeconds;
        }
    }
}
