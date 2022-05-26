using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Object = UnityEngine.Object;

namespace Manager.Core
{
    public class AudioManager
    {
        public static string NAME = "@Sounds";
        private AudioSource[] _audioSources = new AudioSource[Enum.GetValues(typeof(Define.Sound)).Length];
        private Dictionary<string, AudioSource> _audioClips = new Dictionary<string, AudioSource>();

        public void Initialize()
        {
            GameObject root = GameObject.Find(NAME);

            if (root != null) return;
            
            root = new GameObject {name = NAME};
            Object.DontDestroyOnLoad(root);
                
            string[] soundNames = Enum.GetNames(typeof(Define.Sound));
            
            for (int i = 0; i < soundNames.Length; i++)
            {
                GameObject go = new GameObject {name = soundNames[i]};
                _audioSources[i] = go.AddComponent<AudioSource>();
                go.transform.parent = root.transform;
            }
            
            _audioSources[(int) Define.Sound.Bgm].loop = true;
        }

        public void Clear()
        {
            foreach (AudioSource audioSource in _audioSources)
            {
                audioSource.clip = null;
                audioSource.Stop();
            }
            
            _audioClips.Clear();
        }
        
        
    }
}