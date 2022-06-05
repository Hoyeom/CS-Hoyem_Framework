namespace Utils
{
    public class Define
    {
        public enum Sound
        {
            Bgm,
            Effect,
        }
        
        public enum Scene
        {
            None,
        }
        
        public enum UIEvent
        {
            Click
        }
        
        public enum Table
        {
            None,
            CharacterStatus,
        }

        public enum Layer
        {
            BlockLayer = 1 << 3,
        }
    }
}