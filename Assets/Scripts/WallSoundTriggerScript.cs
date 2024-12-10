using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 class WallSoundTriggerScript : MonoBehaviour
{
    [SerializeField] private AudioSource wallAudioSource;
    private bool hasPlayed = false; // Ensures the sound plays only once

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            hasPlayed = true; // Prevent further sound playback
            wallAudioSource.Play();
        }
    }
}
