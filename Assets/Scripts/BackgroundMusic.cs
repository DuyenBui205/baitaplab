using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to this GameObject
        audioSource.loop = true; // Set loop mode to true for continuous playback
        audioSource.Play(); // Start playing background music
    }

    // This function will be called if you want to toggle music with a button
    public void ToggleMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause(); // Pause the music if it's currently playing
        }
        else
        {
            audioSource.Play(); // Play the music from where it left off if it's paused
        }
    }

    // This function is used to adjust the volume
    public void SetVolume(float volume)
    {
        audioSource.volume = volume; // Assign the volume value (0.0 ~ 1.0) to the AudioSource
    }
}