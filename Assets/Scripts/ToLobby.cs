using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class ToLobby: MonoBehaviour
{
    [Inject] private LevelTransitionAnimation _levelTransitionAnimation;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _levelTransitionAnimation.LevelTransition(() =>
            {
                SceneManager.LoadScene(0);
            });
        }
    }
}