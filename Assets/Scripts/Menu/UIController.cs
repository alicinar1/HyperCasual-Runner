using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private Canvas _startGameCanvas;
    [SerializeField] private Canvas _pauseGameCanvas;
    [SerializeField] private Canvas _endGameCanvas;
    [SerializeField] private Canvas _inGameCanvas;


    private void OnEnable()
    {
        MenuController.OnStartGame += StartGameScreen;
        MenuController.OnPauseGame += StopGameScreen;
        MenuController.OnResumeGame += ResumeGameScreen;
    }

    private void OnDisable()
    {
        MenuController.OnStartGame -= StartGameScreen;
        MenuController.OnPauseGame -= StopGameScreen;
        MenuController.OnResumeGame -= ResumeGameScreen;
    }

    private void StartGameScreen()
    {
        Debug.Log("InGameCanvas");
        _startGameCanvas.gameObject.SetActive(false);
        _inGameCanvas.gameObject.SetActive(true);
    }

    private void StopGameScreen()
    {
        Debug.Log("PauseGameCanvas");
        _inGameCanvas.gameObject.SetActive(false);
        _pauseGameCanvas.gameObject.SetActive(true);
    }

    private void ResumeGameScreen()
    {
        Debug.Log("InGameCanvas");
        _pauseGameCanvas.gameObject.SetActive(false);
        _inGameCanvas.gameObject.SetActive(true);
    }

    private void EndGameScreen()
    {
        _startGameCanvas.gameObject.SetActive(false);
        _inGameCanvas.gameObject.SetActive(false);
        _pauseGameCanvas.gameObject.SetActive(false);
        _endGameCanvas.gameObject.SetActive(true);
    }
}
