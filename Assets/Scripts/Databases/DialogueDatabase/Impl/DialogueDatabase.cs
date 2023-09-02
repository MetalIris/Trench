using System;
using System.Collections.Generic;
using DefaultNamespace.Databases.DialogueDatabase.Impl;
using UnityEngine;

namespace Databases.DialogueDatabase.Impl
{
    [CreateAssetMenu(fileName = "DialogueDatabase", menuName = "Database/DialogueDatabase")]
    
    public class DialogueDatabase: ScriptableObject, IDialogueDatabase
    {
        [SerializeField] private List<DialogueVo> dialogue;

        private Dictionary<string, string[]> _dialogueLinesDictionary;
        
        private void OnEnable()
        {
            _dialogueLinesDictionary = new Dictionary<string, string[]>();

            foreach (var DialogueVo in dialogue)
                _dialogueLinesDictionary.Add(DialogueVo.name, DialogueVo.dialogueLines);
        }
        
        public string[] GetDialogueArray(string keyName)
        {
            try
            {
                return _dialogueLinesDictionary[keyName];
            }
            catch (KeyNotFoundException)
            {
                throw new Exception(
                    $"[{nameof(DialogueDatabase)}] Prefab with name {keyName} was not present in the dictionary.");
            }
        }
    }
}