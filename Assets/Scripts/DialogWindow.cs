using Databases.LevelCheckDatabase.Impl;
using DefaultNamespace.Databases.DialogueDatabase.Impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DialogWindow : MonoBehaviour
{
    [Inject] private IDialogueDatabase _dialogueDatabase;
    [Inject] private DialogueManager _dialogueManager;
    [Inject] private ILevelNameDatabase _levelNameDatabase;
    
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private Button _nextDialogueButton;

    private string[] _currentDialogue;
    private int _currentIndex;

    private void Start()
    {
        _nextDialogueButton.onClick.AddListener(NextDialogueButton);

        var currentChapter = PlayerPrefs.GetInt("CurrentLevel");
        var levelName = _levelNameDatabase.GetChapterCount(currentChapter);
        _currentDialogue = _dialogueDatabase.GetDialogueArray(levelName);
        _currentIndex = 0;
        
        DisplayCurrentDialogue();
    }

    private void NextDialogueButton()
    {
        _currentIndex++;
        if (_currentIndex < _currentDialogue.Length)
        {
            DisplayCurrentDialogue();
        }
        else
        {
            gameObject.SetActive(false);
            _dialogueManager.GetToNextLevel();
        }
    }

    private void DisplayCurrentDialogue()
    {
        _dialogueText.text = _currentDialogue[_currentIndex];
    }
}
