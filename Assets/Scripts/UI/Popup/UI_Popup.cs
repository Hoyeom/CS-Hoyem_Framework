using UnityEngine;

namespace UI.Popup
{
    public class UI_Popup : UI_Base
    {
        public override void Initialize()
        {
            Managers.UI.SetCanvas(gameObject, true);
        }

        public virtual void ClosePopupUI()
        {
            Managers.UI.ClosePopupUI(this);
        }
    }
}