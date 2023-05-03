using Items.Data;
using UnityEngine;

namespace Items.Scriptable
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "ItemsSystem/ItemData")]
    public class ItemScriptable : ScriptableObject
    {
        [SerializeField] private ItemDescriptor _descriptor;

        public ItemDescriptor Descriptor => _descriptor;
    }
}
