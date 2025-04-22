using Sirenix.OdinInspector;
using UnityEngine;

namespace UnityRPGEditor
{
    [CreateAssetMenu(menuName = "RPG Editor/New Skill")]
    public class SkillData : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField, TextArea]
        public string Descriptions { get; private set; }

        [field: SerializeField, PreviewField(Height = 100)]
        public Sprite Icon { get; private set; }

        [field: SerializeField]
        public float Cooldown { get; private set; } = 5f;

        [field: SerializeField]
        public float CastDuration { get; private set; } = 0.75f;

        [field: SerializeField]
        public float AfterCastDelay { get; private set; } = 0.25f;

        [field: SerializeField]
        public int ManaCost { get; private set; } = 5;

    }

}

