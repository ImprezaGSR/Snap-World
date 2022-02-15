using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f,1f)]
    public float volume;
    [Range(0f, 1f)]
    public float spatialBlend;
    [Range(.1f, 3f)]
    public float pitch;
    public bool loop;
    public AudioRolloffMode rolloffMode;
    public float minDistance;
    public float maxDistance;

    [HideInInspector]
    public AudioSource source;
}
