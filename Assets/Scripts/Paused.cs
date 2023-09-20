using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Paused : MonoBehaviour
{
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private Button _pauseButton;

    [SerializeField] private GameObject _pausePanel;

    private void Start()
    {
        _resumeButton.onClick.AddListener(ResumeGame);
        _menuButton.onClick.AddListener(ToMenu);
        _pauseButton.onClick.AddListener(PauseGame);
    }
    
    private void ResumeGame()
    {
        Time.timeScale = 1f;
        _pausePanel.SetActive(false);
        _pauseButton.enabled = true;
    }

    private void ToMenu()
    {
        SceneManager.LoadScene(10);
    }
    
    private void PauseGame()
    {
        Time.timeScale = 0f;
        _pausePanel.SetActive(true);
        _pauseButton.enabled = false;
    }
}
