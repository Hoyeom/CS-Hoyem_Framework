using UnityEngine;
using Utils;

namespace Manager.Content
{
    public class GameManager
    {
        private string CONTROLLER_NAME = "@Controller";
        
        private PlayerController _controller;
        
        public PlayerController Controller
        {
            get
            {
                if (_controller == null)
                    _controller = Util.GetOrNewComponent<PlayerController>(CONTROLLER_NAME);
                return _controller;
            }
        }
        
        public void Initialize()
        {
            
        }

        public void Clear()
        {
        }
    }
}