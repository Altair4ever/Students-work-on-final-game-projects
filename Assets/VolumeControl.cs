using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioSource musicSource;

    public void AdjustVolume(float volume)
    {
        musicSource.volume = volume;
    }
}
