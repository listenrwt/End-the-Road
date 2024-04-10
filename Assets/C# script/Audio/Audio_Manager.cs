using UnityEngine;
using UnityEngine.Audio;

public class Audio_Manager : MonoBehaviour {

    public Audio_sourse[] Audioes;

    //singleton pattern
    #region

    public static Audio_Manager instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            instance.PlaySound("Background_Music");
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    #endregion 

    public void PlaySound(string name)
    {
        Audio_sourse audio = checkAudio(name);

        if (audio == null)
            return;

        AudioSource AudioS = gameObject.AddComponent<AudioSource>();
        AudioS.volume = audio.volume;
        AudioS.loop = audio.loop;
        AudioS.clip = audio.Music;

        AudioS.Play();

        if(audio.loop == false)
        Destroy(AudioS, audio.DestroyTime);
    }

    private Audio_sourse checkAudio(string _name)
    {
        Audio_sourse AS = null;

        foreach (Audio_sourse Audio in Audioes)
        {
            if (_name != Audio.Name)
                continue;

            AS = Audio;
            break; 
        }
        return AS;       
    }
}
