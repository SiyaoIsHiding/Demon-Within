using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject battleCanvas;

    public float dist;

    public static LevelManager current;
    public enum State
    {
        Battle,
        Normal
    }

    [SerializeField] private State _currentState;

    private void Awake()
    {
        current = this;
    }

    public Action becomeFighting;

    public void IsAvailableInteract(Boolean available)
    {
        
    }
    void Start()
    {
        InputController.current.onEscapePressed += Pause;
        InputController.current.onSpacePressed += Resume;
        _currentState = State.Normal;
        OnEnterState(_currentState);
    }

    private void Update()
    {
        OnUpdateState(_currentState);
    }

    #region FSM

    public void SetState(State argNewState)
    {
        OnExitState(_currentState);
        _currentState = argNewState;
        OnEnterState(_currentState);
    }

    private void OnUpdateState(State argState)
    {
        switch (argState)
        {
            case State.Battle:
                UpdateBattle();
                return;
            case State.Normal:
                UpdateNormal();
                return;
        }
    }

    private void OnEnterState(State argState)
    {
        switch (argState)
        {
            case State.Battle:
                OnEnterBattle();
                return;
            case State.Normal:
                OnEnterNormal();
                return;
        }
    }

    private void OnExitState(State argState)
    {
        switch (argState)
        {
            case State.Battle:
                OnExitBattle();
                return;
            case State.Normal:
                OnExitNormal();
                return;
        }
    }

    #endregion //FSM

    #region Pause

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

    #endregion

    #region Battle

    private void OnEnterBattle()
    {
        battleCanvas.SetActive(true);
    }

    private void UpdateBattle()
    {
        // detect distance between player and enemy to go normal state
        float dist = Vector3.Distance(player.transform.position, enemy.transform.position);
        if (dist > Constants.ENTER_BATTLE_DISTANCE)
        {
            SetState(State.Normal);
        }

        this.dist = dist;
    }

    private void OnExitBattle()
    {
        battleCanvas.SetActive(false);
    }

    #endregion

    #region Normal

    private void OnEnterNormal()
    {
    }

    private void UpdateNormal()
    {
        //detect distance to go battle state
        float dist = Vector3.Distance(player.transform.position, enemy.transform.position);
        if (dist < Constants.ENTER_BATTLE_DISTANCE)
        {
            SetState(State.Battle);
        }

        this.dist = dist;
    }

    private void OnExitNormal()
    {
    }

    #endregion
}