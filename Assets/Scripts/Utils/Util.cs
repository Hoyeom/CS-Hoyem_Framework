using UnityEngine;

namespace Utils
{
    public class Util
    {
        public static T GetOrAddObject<T>(string name) where T : Component
        {
            GameObject go = GameObject.Find(name);
            if (go != null)
            {
                go = new GameObject(name);
                go.AddComponent(typeof(T));
            }
            
            return go.GetComponent<T>();
        }
    }
}