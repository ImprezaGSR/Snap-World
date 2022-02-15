using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public Sound[] musics;
    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds){

            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.spatialBlend;
            s.source.rolloffMode = s.rolloffMode;
            s.source.minDistance = s.minDistance;
            s.source.maxDistance = s.maxDistance;
        }
    }

    public void Play(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null){
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        s.source.pitch = 1;
        s.source.Play();
    }
    public void Stop(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null){
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.pitch = 0;
    }
    public void ResumeAudio(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null){
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.pitch = 1;
    }
    public void SetVolume(string name, float vol){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null){
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.volume = vol;
    }
    public void SetPitch(string name, float pitch){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null){
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.pitch = pitch;
    }
    public void AdjustVolume(float value){
        foreach(Sound s in sounds){
            if (s.name != "Midnight Cruiser"){
                s.source.volume = value;
            }
        }
    }
    public void AdjustMusic(float value){
        foreach(Sound s in sounds){
            if(s.name == "Midnight Cruiser"){
                s.source.volume = value * 0.3f;
            }
        }
    }

    public float getVolume(){
        Sound s = sounds[0];
        return s.source.volume;
    }
    public float getMusic(){
        foreach(Sound s in sounds){
            if(s.name == "Midnight Cruiser"){
                return (s.source.volume / 0.3f);
            }
        }return 1f;
    }
}
