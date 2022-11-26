using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;

public class KillCounter : MonoBehaviour
{
    public TextMeshProUGUI _killNumber;
    public TextMeshProUGUI _killNumberShadow;
    public int _killCount;
    public int _totalEnemies;
    public Fade _fadeControll;
    public int _gameState;

    private void Start()
    {
        _totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length; 
        _killNumber.text = _killCount + "/" + _totalEnemies;
        _killNumberShadow.text = _killCount + "/" + _totalEnemies;
    }
    public void KillCount()
    {
        _killCount++;
        _killNumber.text = _killCount + "/" + _totalEnemies;
        _killNumberShadow.text = _killCount + "/" + _totalEnemies;
        LevelComplete();
    }

    public void RefreshTotal()
    {
        _totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        _killNumber.text = _killCount + "/" + _totalEnemies;
        _killNumberShadow.text = _killCount + "/" + _totalEnemies;
    }

    public void LevelComplete()
    {
        if (_killCount == _totalEnemies)
        {
            GameState.PhaseChange();
            _gameState = GameState.GameStateRead();
            Invoke("ChangeScene", 2f);
        }
    }

    public void ChangeScene()
    {
        if (_gameState < 2)
        {
            _fadeControll.FadeToLevel(1);
        }
        
        else
        {
            _fadeControll.FadeToLevel(3);
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
