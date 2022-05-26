using Manager.Core;
using UnityEngine;
using Utils;

public class Managers : MonoBehaviour
{
    private static Managers _instance;
    public static Managers Instance
    {
        get
        {
            Initialize();
            return _instance;
        }
    }


    private static string MANAGERS_NAME = "@Managers";

    private AudioManager _audio = new AudioManager();
    
    
    private static void Initialize()
    {
        if(_instance != null) return;

        _instance = Util.GetOrAddObject<Managers>(MANAGERS_NAME);
        
        _instance._audio.Initialize();
    }

}