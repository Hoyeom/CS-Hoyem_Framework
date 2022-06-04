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

        private CameraController _camera;

        public CameraController Camera
        {
            get
            {
                if (_camera == null && UnityEngine.Camera.main != null)
                    _camera = UnityEngine.Camera.main.gameObject.GetOrAddComponent<CameraController>();
                return _camera;
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