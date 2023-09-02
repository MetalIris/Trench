using System;
using System.Collections.Generic;
using UnityEngine;

namespace Databases.PlayerSpriteDatabase.Impl
{
    [CreateAssetMenu(fileName = "PlayerSpriteDatabase", menuName = "Database/PlayerSpriteDatabase")]
    public class PrefabDatabase : ScriptableObject, IPrefabDatabase
    {
        [SerializeField] private List<PrefabVo> sprites;

        private Dictionary<string, GameObject> _prefabDictionary;

        private void OnEnable()
        {
            _prefabDictionary = new Dictionary<string, GameObject>();

            foreach (var prefabVo in sprites)
                _prefabDictionary.Add(prefabVo.name, prefabVo.gameObject);
        }

        public GameObject GetPrefab(string keyName)
        {
            try
            {
                return _prefabDictionary[keyName];
            }
            catch (KeyNotFoundException)
            {
                throw new Exception(
                    $"[{nameof(PrefabDatabase)}] Prefab with name {keyName} was not present in the dictionary.");
            }
        }
    }
}
