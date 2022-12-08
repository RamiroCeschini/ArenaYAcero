using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject _blueEnemy;
    public GameObject _redEnemy;
    public GameObject _bossEnemy;
    public int _blueSpawnCount;
    public int _redSpawnCount;
    public int _bossSpawnCount;
    public int _gameStage;
    public KillCounter _killCounter;
    void Start()
    {
        _blueSpawnCount = 0;
        _redSpawnCount = 0;
        _bossSpawnCount = 0;
        Invoke("GameMoment", 2f);
        _gameStage = GameState.GameStateRead();
        Debug.Log("StartSpawn");
    }

    IEnumerator EnemyDrop(int totalTypeEnemies, int typeSpawnCount, GameObject enemyType)
    {
        while (typeSpawnCount < totalTypeEnemies)
        {
            Instantiate(enemyType);
            yield return new WaitForSeconds(0.5f);
            _killCounter.RefreshTotal();
            typeSpawnCount++;
            Debug.Log("Spawn");
        }
    }


    private void GameMoment()
    {
        if (_gameStage == 0)
        {
            StartCoroutine(EnemyDrop(2, _blueSpawnCount, _blueEnemy));
            StartCoroutine(EnemyDrop(1, _redSpawnCount, _redEnemy));
        }

        else if (_gameStage == 1)
        {
            StartCoroutine(EnemyDrop(1, _bossSpawnCount, _bossEnemy));
            StartCoroutine(EnemyDrop(2, _redSpawnCount, _redEnemy));
        }

        else if (_gameStage == 2)
        {
            StartCoroutine(EnemyDrop(2, _bossSpawnCount, _bossEnemy));
        }

    }
}
