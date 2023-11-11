using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    public PlayerInput playerInput;
    // Start is called before the first frame update
    void Start()
    {
        InputController.current.onEscapePressed += Pause;
        InputController.current.onSpacePressed += Resume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        playerInput.SwitchCurrentActionMap("Pause");
        Debug.Log("pause");
        Time.timeScale = 0f;
        pauseCanvas.SetActive(true);
    }

    public void Resume()
    {
        playerInput.SwitchCurrentActionMap("Play");
        Debug.Log("resume");
        Time.timeScale = 1f;
        pauseCanvas.SetActive(false);
    }
}
