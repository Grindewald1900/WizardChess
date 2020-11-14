using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource attackAudio;
    public AudioSource getAttackAudio;
    public AudioSource dieAudio;

    public static AudioPlayer SharedInstance;
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log(GetComponents<AudioSource>());

        SharedInstance = this;
        attackAudio = GetComponents<AudioSource>()[0];
        getAttackAudio = GetComponents<AudioSource>()[1];
        dieAudio = GetComponents<AudioSource>()[2];

    }

    public void PlayAttackAudio()
    {
        attackAudio.Play();
    }
    public void PlayGetAttackAudio()
    {
        getAttackAudio.Play();
    }
    public void PlayDieAudio()
    {
        dieAudio.Play();
    }
}
