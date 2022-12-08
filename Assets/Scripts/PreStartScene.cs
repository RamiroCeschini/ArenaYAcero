using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreStartScene : MonoBehaviour
{
    public Fade _fade;
    public GameObject _quote;
    public GameObject _title;


    private void Start()
    {
        _fade.JustFade();
    }

    public void Swap()
    {
        _quote.SetActive(false);
        _title.SetActive(true);    
    }
}
