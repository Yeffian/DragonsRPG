using UnityEngine;

[System.Serializable]
public class Sound
{
        public AudioClip Clip;
        public string Name;

        [Range(0.0f, 1.0f)]
        public float Volume;
        
        [Range(0.1f, 3.0f)]
        public float Pitch;

        [HideInInspector]
        public AudioSource Source;
}
