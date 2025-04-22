using UnityEngine;
using Sirenix.OdinInspector;

namespace UnityRPGEditor
{
    [CreateAssetMenu(menuName = "RPG Editor/New Character")]
    public class CharacterData : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public string Backstory { get; private set; }

        [field: SerializeField, PreviewField(Height = 100)]
        public Sprite Portrait { get; private set; }

        [field: SerializeField, InlineEditor]
        public ClassData Class { get; private set; }

        [field: SerializeField]
        public WeaponData EquippedWeapon { get; private set; }

        [field: SerializeField]
        public ItemData[] Inventory { get; private set; }
    }
}
