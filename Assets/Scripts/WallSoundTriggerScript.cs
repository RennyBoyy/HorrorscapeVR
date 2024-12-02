using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSoundTriggerScript : MonoBehaviour
{
    [SerializeField] private AudioSource wallAudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            wallAudioSource.Play();
        }
    }
}