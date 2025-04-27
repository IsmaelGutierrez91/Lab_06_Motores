using System;
using UnityEngine;
using UnityEngine.Audio;

public class InteractuableObject : MonoBehaviour
{
    [SerializeField] private AudioData audioData;
    [SerializeField] private AudioSettings audioSettings;

    public static event Action<AudioMixerGroup, AudioClip> OnCollisionMusic;
    public static event Action OnCollisionMusicExit;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollisionMusic?.Invoke(audioSettings.AudioMixerGroup, audioData.AudioClip);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollisionMusicExit?.Invoke();
        }
    }
}
