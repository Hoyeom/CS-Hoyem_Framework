namespace UI.UI_Scene
{
    public class UI_Scene : UI_Base
    {
        public override void Initialize()
        {
            Managers.UI.SetCanvas(gameObject,false);
        }
    }
}