using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum SoundType
{
    BREAKING_1,
    BREAKING_2,
    LEVEL_UP,
    UPGRADE_TEAM
}


[Serializable]
public class SoundData
{
    public SoundType Sound;
    public AudioClip Clip;
}

[CreateAssetMenu]
public class AudioManager : ScriptableObject
{
    public float Volume = 1;
    public List<SoundData> Sounds = new();

    public AudioClip GetClip(SoundType type)
    {
        for (var i = 0; i < Sounds.Count; i++)
            if (Sounds[i].Sound == type)
                return Sounds[i].Clip;
        return null;
    }

    public void PlayOnce(SoundType soundType, bool randomPitch, float volume)
    {
        var clip = GetClip(soundType);
        var gm = new GameObject($"Audio{soundType}");
        DontDestroyOnLoad(gm);
        var sc = gm.AddComponent<AudioSource>();
        sc.clip = clip;
        sc.volume = Volume * volume;
        if (randomPitch)
            sc.pitch = Random.Range(sc.pitch - 0.3f, sc.pitch + 0.3f);
        sc.Play();
        Destroy(gm, clip.length);
    }
}