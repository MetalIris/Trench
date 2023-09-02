using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class LevelController: MonoBehaviour
{
    [Inject] private LevelPassedController _levelPassedController;

    [Header("UI")]
    [SerializeField] private GameObject controller;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button restartButton;
    [SerializeField] private GameObject enemiesLeftPanel;
    
    [SerializeField] private GameObject levelPassedArrow;
    [SerializeField] private GameObject toLobby;
    
    [SerializeField] private Image[] enemyHead;
    [SerializeField] private Sprite killedEnemy;
    [SerializeField] private int enemiesKilled;

    [Header("SceneConfigs")]
    public int enemyCountOnScene;

    private void Start()
    {
        for (var i = 0; i < enemyCountOnScene; i++)
        {
            enemyHead[i].enabled = true;
        }
    }

    private void Update()
    {
        enemiesKilled = enemyCountOnScene - _levelPassedController._enemiesCount;

        if (enemiesKilled <= 0) return;
        
        var lastEnemyIndex = enemyHead.Length - enemiesKilled;

        if (lastEnemyIndex < 0 || lastEnemyIndex >= enemyHead.Length) return;
        
        var lastEnemySprite = enemyHead[lastEnemyIndex];
                
        if (lastEnemySprite != null)
        {
            lastEnemySprite.sprite = killedEnemy;
        }
    }

    public void OnLevelComplete()
    {
        levelPassedArrow.SetActive(true);
        toLobby.SetActive(true);
    }
    
    private void OnRestartLevel()
    {
        var currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        SceneManager.LoadScene(currentLevel + 1);
    }
    
    public void OnPlayerKilled()
    {
        controller.SetActive(false);
        enemiesLeftPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        
        restartButton.onClick.AddListener(OnRestartLevel);
    }
}
