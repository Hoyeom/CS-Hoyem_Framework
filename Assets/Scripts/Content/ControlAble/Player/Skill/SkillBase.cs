using System;
using UnityEngine;
using Utils;

namespace Content
{
    public abstract class SkillBase
    {
        protected SkillInfo _info;
        public SkillInfo Info => _info;
        
        protected delegate void SkillChain(Define.PressEvent phase);
        protected SkillChain TriggerChain { get; set; }

        private float _coolDownTimer = 0;
        private float _chargeTimer = 0;
        private bool _isCharge = false;
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

        public float Charge
        {
            get => _chargeTimer;
            set
            {
                _chargeTimer = value;
                if (_info.ChargeTime < _chargeTimer && _isCharge)
                {
                    Fire();
                }
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
            }
        }

        public void OnUpdate()
        {
            CoolDown -= Time.deltaTime;
            Charge += Time.deltaTime;
        }

        public void Active(Define.PressEvent phase)
        {
            TriggerChain?.Invoke(phase);
        }

        private void OnPress(Define.PressEvent phase)
        {
            switch (phase)
            {
                case Define.PressEvent.Down:
                    Fire();
                    break;
            }
        }

        private void OnHold(Define.PressEvent phase)
        {
            switch (phase)
            {
                case Define.PressEvent.Down:
                    _isCharge = true;
                    _chargeTimer = 0;
                    break;
                case Define.PressEvent.Up:
                    ChargeFire(ChargeNormalTime);
                    break;
            }
        }

        protected virtual void Fire()
        {
            
        }

        protected virtual void ChargeFire(float chargeTime)
        {
            
        }

        private float ChargeNormalTime => _chargeTimer / _info.ChargeTime;
    }
}