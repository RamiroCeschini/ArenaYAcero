using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public Animator _fadeAnimator;
    private int _levelToLoad;
    public bool _changeScene = true;
    public PreStartScene _preStartScene;

    public void FadeToLevel(int levelIndex)
    {
        _fadeAnimator.SetTrigger("FadeOut");
        _levelToLoad = levelIndex;
        
    }

    public void JustFade()
    {
        StartCoroutine(Wait());
        _changeScene = false;
    }

    public void OnFadeComplete()
    {
        if (_changeScene == true)
        {
            SceneManager.LoadScene(_levelToLoad);
        }

        else
        {
            _fadeAnimator.SetTrigger("FadeIn");
            _changeScene=true;
            _levelToLoad=1;
            _preStartScene.Swap();
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4f);
        _fadeAnimator.SetTrigger("FadeOut");

    }

}
