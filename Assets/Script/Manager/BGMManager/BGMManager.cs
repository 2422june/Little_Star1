using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{

    public static BGMManager i;
    void Awake()
    {
        if (i == null)
        {
            i = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    [SerializeField]
    public AudioSource Bgm, Eft;

    public List<AudioClip> BGM, EFT;
    int state;
    public float volume = 1;

    void Start()
    {
        volume = 0;
    }

    public void BGMPlay(int _state)
    {
        state = _state;
        Bgm.clip = BGM[state];
        Bgm.Play();
    }

    public void EFTPlay(int _state)
    {
        state = _state;
        Eft.clip = EFT[state];
        Eft.Play();
    }

    public void BgmPause()
    {
        Bgm.Pause();
    }

    public void BGMOnLoop(bool isOn){
        Bgm.loop = isOn;
    }

    public void SetBGMVolume(float _volume)
    {
        volume = _volume;
        Bgm.volume = volume;
    }

    public void SetEftVolume(float _volume)
    {
        volume = _volume;
        Eft.volume = volume;
    }
}
