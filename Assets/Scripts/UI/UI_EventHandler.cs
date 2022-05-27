using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class UI_EventHandler : MonoBehaviour,IPointerClickHandler
    {
        public event Action<PointerEventData> OnClickHandler = null;

        public void OnPointerClick(PointerEventData eventData)
            => OnClickHandler?.Invoke(eventData);
    }
}