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
        }

        [SerializeField] private SkillTrigger trigger;
        [SerializeField] private float coolDown;
        [SerializeField] private float charge;
        [SerializeField] private AnimationClip clip;

        public SkillTrigger Trigger { get => trigger; }
        public float CoolDown => coolDown;
        public float ChargeTime => charge;
        public AnimationClip Clip => clip;
    }
}