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
        private Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

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

        public void Play(AudioClip audioClip,Define.Sound type = Define.Sound.Effect)
        {
            if(audioClip == null)
                return;
            if (type == Define.Sound.Bgm)
            {
                AudioSource audioSource = _audioSources[(int) Define.Sound.Bgm];
                
                if(audioSource.isPlaying)
                    audioSource.Stop();

                audioSource.clip = audioClip;
                audioSource.Play();
            }
            else
            {
                AudioSource audioSource = _audioSources[(int) Define.Sound.Effect];
                audioSource.PlayOneShot(audioClip);
            }
        }

        public void Play(string path, Define.Sound type = Define.Sound.Effect)
        {
            AudioClip audioClip = GetOrAddAudioClip(path,type);
            Play(audioClip,type);
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

        AudioClip GetOrAddAudioClip(string path, Define.Sound type = Define.Sound.Effect)
        {
            if (path.Contains("Sounds/") == false)
                path = $"Sounds/{path}";

            AudioClip audioClip = null;

            if (type == Define.Sound.Bgm)
            {
                audioClip = Managers.Resource.Load<AudioClip>(path);
            }
            else if(_audioClips.TryGetValue(path,out audioClip) == false)
            {
                audioClip = Managers.Resource.Load<AudioClip>(path);
                _audioClips.Add(path,audioClip);
            }

            if (audioClip == null)
                throw new Exception($"Missing Path {path}");

            return audioClip;
        }
    }
}