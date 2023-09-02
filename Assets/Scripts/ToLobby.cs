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
            // Запускаємо анімацію переходу
            _levelTransitionAnimation.LevelTransition(() =>
            {
                // По закінченні анімації переходимо на наступний рівень
                SceneManager.LoadScene(0);
            });
        }
    }
}