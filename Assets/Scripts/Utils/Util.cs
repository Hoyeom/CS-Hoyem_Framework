using UnityEngine;

namespace Utils
{
    public class Util
    {
        
        /// <summary>
        /// 해당 이름의 컴포넌트를 반환 또는
        /// 새로운 오브젝트를 생성하여 컴포넌트를 추가한다 
        /// </summary>
        /// <param name="name">찾을이름</param>
        /// <typeparam name="T">컴포넌트</typeparam>
        /// <returns></returns>
        public static T GetOrNewComponent<T>(string name) where T : Component
        {
            GameObject go = GameObject.Find(name);
            if (go == null)
            {
                go = new GameObject(name);
                go.AddComponent(typeof(T));
            }
            
            return go.GetComponent<T>();
        }
    }
}