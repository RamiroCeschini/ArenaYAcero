using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; }

    private int GamePhase = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public int GameStateRead()
    {
        return GamePhase;
    }

    public void PhaseChange()
    {
        GamePhase++;
        Debug.Log("Gamephase +1");
    }
}
