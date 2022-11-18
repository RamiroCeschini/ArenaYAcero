using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyController : MonoBehaviour
{
    public GameObject _dialoguePanel;

    public void NPCTrigger()
    {
       _dialoguePanel.SetActive(true);
        Debug.Log("Trigger");
    }





}

