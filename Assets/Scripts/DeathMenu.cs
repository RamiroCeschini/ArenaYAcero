using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    public Fade _fade;
    public GameState _gameState;
    public int _gamePhase;

    private void Start()
    {
        _fade = GameObject.FindGameObjectWithTag("Fade").GetComponent<Fade>();
    }

    public void PlayGame()
    {
        _fade.FadeToLevel(2);
    }
    public void ButtonTry()
    {
        _fade.FadeToLevel(3);
    }

    public void ButtonExit()
    {
        _fade.FadeToLevel(1);
        Time.timeScale = 1.0f;
        ReadPhase();
        if (_gamePhase == 3)
        {
            GameState.RestartGame();
        }
    }

    public void ReadPhase()
    {
        _gamePhase = GameState.GameStateRead();
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Salio");
    }
}
