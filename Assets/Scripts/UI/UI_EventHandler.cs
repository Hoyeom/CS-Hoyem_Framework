using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class UI_EventHandler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {
        private float _defaultSize = 1.0f;
        private float _downSize = 0.85f;
        private float _tweenSpeed = 0.2f;
        
        public event Action<PointerEventData> OnClickHandler = null;
        public event Action<PointerEventData> OnDownHandler = null;
        public event Action<PointerEventData> OnUpHandler = null;

        public void OnPointerClick(PointerEventData eventData)
            => OnClickHandler?.Invoke(eventData);

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDownHandler?.Invoke(eventData);
            transform.DOScale(_downSize, _tweenSpeed);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnUpHandler?.Invoke(eventData);
            transform.DOScale(_defaultSize, _tweenSpeed);
        }
    }
}