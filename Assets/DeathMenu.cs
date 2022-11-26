using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    public Fade _fade;

    public void ButtonTry()
    {
        _fade.FadeToLevel(2);
    }

    public void ButtonExit()
    {
        _fade.FadeToLevel(1);
        Time.timeScale = 1.0f;
    }

    public void ReplayGame()
    {
        _fade.FadeToLevel(1);
        GameState.RestartGame();
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Salio");
    }
}
