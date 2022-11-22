using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks.Sources;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public GameObject _dialoguePanel;
    public GameObject _NPCLight;
    public GameObject _levelTrigger;
    public Animator _NPCanim;
    public FPSController _playerScript;
    public Fade _fadeController;

    public void NPCTrigger()
    {
       _dialoguePanel.SetActive(true);
        _NPCLight.SetActive(false);
        _NPCanim.SetTrigger("Talk");

        _playerScript._walkSpeed = 0;
        _playerScript._runSpeed = 0;
        _playerScript._jumpSpeed = 0;
        Debug.Log("Trigger");
    }

    public void NPCTriggerOff()
    {
        _dialoguePanel.SetActive(false);
        _NPCanim.SetTrigger("Idle");
        _playerScript._walkSpeed = 3;
        _playerScript._runSpeed = 6;
        _playerScript._jumpSpeed = 8;
        _levelTrigger.SetActive(true); 
    }
    
    public void GoToScene()
    {
        _fadeController.FadeToLevel(1);
    }




}

