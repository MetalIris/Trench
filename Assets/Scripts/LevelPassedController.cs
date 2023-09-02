using UnityEngine;
using Zenject;

public class LevelPassedController: IInitializable
{
    private int _currentLevel; 
        
    [Inject] private LevelController _levelController;
        
    public int _enemiesCount;
        
    public void Initialize()
    {
        _enemiesCount = _levelController.enemyCountOnScene;
        _currentLevel = PlayerPrefs.GetInt("CurrentLevel", _currentLevel);
    }

    private void CheckEnemies()
    {
        if (_enemiesCount <= 0)
        {
            _levelController.OnLevelComplete();
                
            _currentLevel++;
            PlayerPrefs.SetInt("CurrentLevel", _currentLevel);
            Debug.Log(_currentLevel);
        }
        Debug.Log(_enemiesCount);
    }
        
    public void EnemyKilled(int count)
    {
        _enemiesCount -= count;
        CheckEnemies();
    }
}