using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public static event Action OnStartGame;
    public static event Action OnPauseGame;
    public static event Action OnResumeGame;

    public void StartGame()
    {
        OnStartGame?.Invoke();
    }

    public void PauseGame()
    {
        OnPauseGame?.Invoke();
    }

    public void ResumeGame()
    {
        OnResumeGame?.Invoke();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
