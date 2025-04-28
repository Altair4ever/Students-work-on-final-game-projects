using UnityEngine;

public class GoalMusicStopper : MonoBehaviour
{
    public AudioSource musicSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            musicSource.Stop();
        }
    }
}
