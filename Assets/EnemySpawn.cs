using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject _blueEnemy;
    public GameObject _redEnemy;
    public int _blueSpawnCount;
    public int _redSpawnCount;
    public int _gameStage;
    public KillCounter _killCounter;
    void Start()
    {
        _blueSpawnCount = 0;
        _redSpawnCount = 0;
        Invoke("GameMoment", 2f);
        _gameStage = GameState.GameStateRead();
        Debug.Log("StartSpawn");
    }

    IEnumerator BlueEnemyDrop(int totalBlueEnemies)
    {
        while (_blueSpawnCount < totalBlueEnemies)
        {
            Instantiate(_blueEnemy);
            yield return new WaitForSeconds(0.5f);
            _killCounter.RefreshTotal();
            _blueSpawnCount++;
            Debug.Log("Spawn");
        }
    }

    IEnumerator RedEnemyDrop(int totalRedEnemies)
    {
        while (_redSpawnCount < totalRedEnemies)
        {
            Instantiate(_redEnemy);
            yield return new WaitForSeconds(0.5f);
            _killCounter.RefreshTotal();
            _redSpawnCount++;
            Debug.Log("Spawn");
        }
    }

    private void GameMoment()
    {
        if (_gameStage == 0)
        {
            StartCoroutine(BlueEnemyDrop(2));
            StartCoroutine(RedEnemyDrop(1));
            Debug.Log("Corutina en 0");
        }

        else if (_gameStage == 1)
        {
            StartCoroutine(BlueEnemyDrop(1));
            StartCoroutine(RedEnemyDrop(3));
            Debug.Log("Corutina en 1");
        }

    }
}
