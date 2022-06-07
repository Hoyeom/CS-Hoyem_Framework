using System;
using UnityEngine;

namespace Content
{
    public class SkillBase
    {
        protected SkillInfo _info;
        public SkillInfo Info => _info;
        
        protected delegate void SkillChain();
        protected SkillChain TriggerChain { get; set; }

        private float _coolDownTimer = 0;
        public event Action<float> OnChangeCoolDown;

        private float CoolDown
        {
            get => _coolDownTimer;
            set
            {
                _coolDownTimer = value;
                OnChangeCoolDown?.Invoke(_coolDownTimer);
            }
        }
        
        public void Initialize(SkillInfo info)
        {
            _info = info;
            SkillInit();
        }

        /// <summary>
        /// TriggerChain 작성
        /// </summary>
        protected void SkillInit()
        {
            _coolDownTimer = _info.CoolDown;
            
            switch (_info.Trigger)
            {
                case SkillInfo.SkillTrigger.Press:
                    TriggerChain += OnPress;
                    break;
                case SkillInfo.SkillTrigger.Hold:
                    TriggerChain += OnHold;
                    break;
                case SkillInfo.SkillTrigger.Passive:
                    TriggerChain += OnPassive;
                    break;
            }
        }

        public void OnUpdate()
        {
            CoolDown -= Time.deltaTime;
        }

        public void Active()
        {
            TriggerChain?.Invoke();
        }

        private void OnPress()
        {
            
        }

        private void OnHold()
        {
            
        }

        private void OnPassive()
        {
            
        }
    }
}