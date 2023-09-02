
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;


public class ToNextLevel : MonoBehaviour
{
    [Inject] private LevelTransitionAnimation _levelTransitionAnimation;

    private int _currentLevel;

    private void Start()
    {
        _currentLevel = PlayerPrefs.GetInt("CurrentLevel");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // Запускаємо анімацію переходу
            _levelTransitionAnimation.LevelTransition(() =>
            {
                // По закінченні анімації переходимо на наступний рівень
                SceneManager.LoadScene(_currentLevel + 1);
            });
        }
    }
}

