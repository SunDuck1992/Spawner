using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject _enemy;
    [SerializeField] Transform[] _pointsOfSpawn;
    [SerializeField] float _secondsBetweenSpawn;

    private Coroutine _coroutine;

    private void Start()
    {
        _coroutine = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var waitForSeconds = new WaitForSeconds(_secondsBetweenSpawn);

        foreach (var spawnPoint in _pointsOfSpawn)
        {
            Instantiate(_enemy, spawnPoint.transform.position, Quaternion.identity);
            yield return waitForSeconds;
        }

        StopCoroutine(_coroutine);
    }
}
