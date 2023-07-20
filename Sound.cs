using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Audio
{
    public string name;

    public AudioClip clip;
    private AudioSource source;

    public float Volumn;
    public bool loop;

    public void Setsource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
        source.loop = loop;
    }

    public void Play()
    {
        source.Play();
    }
    public void Stop()
    {
        source.Stop();
    }
}


public class Sound : MonoBehaviour
{

    [SerializeField]
    public Audio[] sounds;

    void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject soundobject = new GameObject("사운드 파일 이름 : " + i + " = " + sounds[i].name);
            sounds[i].Setsource(soundobject.AddComponent<AudioSource>());
            soundobject.transform.SetParent(this.transform);
        }
    }

    public void Play(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
            {
                sounds[i].Play();
                return;
            }
        }

    }
    public void Stop(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
            {
                sounds[i].Stop();
                return;
            }
        }
    }
}
