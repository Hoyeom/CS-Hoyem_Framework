using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class UI_EventHandler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler,IPointerExitHandler
    {
        enum PointerAnim
        {
            None,
            Size,
        }

        [SerializeField] private PointerAnim pointerAnimEnum = PointerAnim.Size;
        [SerializeField] private float _tweenSpeed = 0.2f;
        
        private float _minValue = 0.85f;
        private float _defaultValue = 1.0f;
        
        public event Action<PointerEventData> OnClickHandler = null;
        public event Action<PointerEventData> OnDownHandler = null;
        public event Action<PointerEventData> OnUpHandler = null;
        
        private Action<float> pointerAnimation;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            switch (pointerAnimEnum)
            {
                case PointerAnim.Size:
                    pointerAnimation = TweenScale;
                    break;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
            => OnClickHandler?.Invoke(eventData);

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDownHandler?.Invoke(eventData);
            pointerAnimation?.Invoke(_minValue);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnUpHandler?.Invoke(eventData);
            pointerAnimation?.Invoke(_defaultValue);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            pointerAnimation?.Invoke(_defaultValue);
        }

        private void TweenScale(float scale)
        {
            transform.DOScale(scale, _tweenSpeed);
        }
    }
}