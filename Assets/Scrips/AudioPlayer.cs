using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private ChannelPlayer musicPlayer;
    [SerializeField] private ChannelPlayer sfxPlayer;
    public static AudioPlayer Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }
    private void OnEnable()
    {
        InteractuableObject.OnCollisionMusic += PlayPlayer;
    }
    private void OnDisable()
    {
        InteractuableObject.OnCollisionMusic -= PlayPlayer;
    }
    private void PlayPlayer(AudioMixerGroup currentGroup, AudioClip currentAudioClip)
    {
        if (currentGroup == musicPlayer.PlayerChannel)
        {
            musicPlayer.PlayerClip(currentAudioClip);
        }
        else
        {
            sfxPlayer.PlayerClip(currentAudioClip);
        }
    }
}
