using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public Animator _fadeAnimator;
    private int _levelToLoad;

    public void FadeToLevel(int levelIndex)
    {
        _fadeAnimator.SetTrigger("FadeOut");
        _levelToLoad = levelIndex;
        
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(_levelToLoad);
    }

}
