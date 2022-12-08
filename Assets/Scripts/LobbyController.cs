using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks.Sources;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public LobbyController _controller;
    public GameObject _dialoguePanel1;
    public GameObject _dialoguePanel2;
    public GameObject _dialoguePanel3;
    public GameObject _triggerPuerta1;
    public GameObject _triggerPuerta2;
    public GameObject _triggerPuerta3;

    public GameObject _canvasClaudio;
    public GameObject _canvasVictory;

    public GameObject _NPCLight;
    public GameObject _levelTrigger;
    public Animator _NPCanim;
    public FPSController _playerScript;
    public Fade _fadeController;
    public int _gameStage;

    private void Start()
    {
        _controller = GetComponent<LobbyController>();
        _gameStage = GameState.GameStateRead();
    }
    public void NPCTrigger(GameObject panelDialogo)
    {
       panelDialogo.SetActive(true);
        _NPCLight.SetActive(false);
        _NPCanim.SetTrigger("Talk");

        _playerScript._walkSpeed = 0;
        _playerScript._runSpeed = 0;
        _playerScript._jumpSpeed = 0;
    }

    public void NPCTriggerOff(GameObject panelDialogo, GameObject triggerPuerta)
    {
        panelDialogo.SetActive(false);
        _NPCanim.SetTrigger("Idle");
        _playerScript._walkSpeed = 3;
        _playerScript._runSpeed = 6;
        _playerScript._jumpSpeed = 8;
        triggerPuerta.SetActive(true); 
    }
    
    public void GoToScene()
    {
        _fadeController.FadeToLevel(3);
    }

    public void GameMomentStart()
    {
        if (_gameStage == 0)
        {
            _controller.NPCTrigger(_dialoguePanel1);
        }

        else if (_gameStage == 1)
        {
            _controller.NPCTrigger(_dialoguePanel2);
        }

        else if (_gameStage == 2)
        {
            _controller.NPCTrigger(_dialoguePanel3);
        }
    }
    public void GameMomentEnd()
    {
        if (_gameStage == 0)
        {
            _controller.NPCTriggerOff(_dialoguePanel1, _triggerPuerta1);
        }

        else if (_gameStage == 1)
        {
            _controller.NPCTriggerOff(_dialoguePanel2, _triggerPuerta2);
        }

        else if (_gameStage == 2)
        {
            _controller.NPCTriggerOff(_dialoguePanel3, _triggerPuerta3);
        }

        else if (_gameStage == 3)
        {
            _canvasVictory.SetActive(true);
            _canvasClaudio.SetActive(false);
        }

    }


}

