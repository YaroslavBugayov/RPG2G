using System.Collections.Generic;
using Items.Data;
using Items.Scriptable;
using UnityEngine;

namespace Items.Storage
{
    [CreateAssetMenu(fileName = "ItemsStorage", menuName = "ItemsSystem/ItemsStorage" ) ]
    public class ItemsStorage : ScriptableObject
    {
        [SerializeField] private List<ItemScriptable> _descriptors;
        
        public IEnumerable<ItemScriptable> Descriptors => _descriptors;
    }
}
