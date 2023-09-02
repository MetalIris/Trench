using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject _dialogueWindow;
    [SerializeField] private GameObject _toNextLevel;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _dialogueWindow.SetActive(true);
        }
    }

    public void GetToNextLevel()
    {
        _toNextLevel.SetActive(true);
    }
}
