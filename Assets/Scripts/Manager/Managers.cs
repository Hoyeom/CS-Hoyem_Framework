using System;
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


    public static string NAME = "@Managers";

    private AudioManager _audio = new AudioManager();
    public static AudioManager Audio => Instance._audio;
    
    private void Awake() => name = NAME;
    private void Start() => Initialize();

    #region ManagerMethod

    private static void Initialize()
    {
        if (_instance != null) return;
        
        MakeInstance(out _instance);
        
        ManagersInit();
    }
    
    private static void MakeInstance(out Managers managers)
    {
        managers = Util.GetOrNewComponent<Managers>(NAME);
        DontDestroyOnLoad(managers);
    }
    
    private static void ManagersInit()
    {
        _instance._audio.Initialize();
    }
    
    public void ManagersClear()
    {
        Audio.Clear();
    }

    #endregion

}