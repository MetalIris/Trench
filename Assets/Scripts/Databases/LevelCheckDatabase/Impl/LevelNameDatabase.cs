using System;
using System.Collections.Generic;
using UnityEngine;

namespace Databases.LevelCheckDatabase.Impl
{
    [CreateAssetMenu(fileName = "LevelNameDatabase", menuName = "Database/LevelNameDatabase")]
    
    public class LevelNameDatabase : ScriptableObject, ILevelNameDatabase
    {
        [SerializeField] private List<LevelNameVo> levelName;

        private Dictionary<int, string> _checkLevelDictionary;
        
        private void OnEnable()
        {
            _checkLevelDictionary = new Dictionary<int, string>();

            foreach (var levelNameVo in levelName)
                _checkLevelDictionary.Add(levelNameVo.chapterCount, levelNameVo.chapterName);
        }
        
        public string GetChapterCount(int chapterName)
        {
            try
            {
                return _checkLevelDictionary[chapterName];
            }
            catch (KeyNotFoundException)
            {
                throw new Exception(
                    $"[{nameof(DialogueDatabase)}] Prefab with name {chapterName} was not present in the dictionary.");
            }
        }
    }
}