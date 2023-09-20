using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button _exitButton;
    void Start()
    {
        _startButton.onClick.AddListener(StartGame);
        _optionsButton.onClick.AddListener(OpenOptions);
        _exitButton.onClick.AddListener(ExitGame);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(0);
        Debug.Log("sdasdasd");
    }

    private void OpenOptions()
    {
        
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
