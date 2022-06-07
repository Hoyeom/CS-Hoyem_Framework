using UnityEngine;

namespace Content
{
    [CreateAssetMenu(menuName = "SkillInfo", fileName = "NewSkillInfo")]
    public class SkillInfo : ScriptableObject
    {
        public enum SkillTrigger
        {
            Press,
            Hold,
            Passive
        }

        [SerializeField] private SkillTrigger trigger;
        [SerializeField] private float coolDown;
        [SerializeField] private AnimationClip clip;

        public SkillTrigger Trigger { get => trigger; }
        public float CoolDown => coolDown;
        public AnimationClip Clip => clip;
    }
}