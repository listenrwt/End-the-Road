using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Audio_sourse {

    public string Name;
    public AudioClip Music;
    [Range(0f,1f)]
    public float volume;
    public bool loop;
    public float DestroyTime;

}
