using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrabAndCollect : MonoBehaviour
{
    public AudioClip collectionSound; // Add your audio file in the Inspector
    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor currentInteractor; // Tracks the hand grabbing the object
    private float grabTime = 5f; // Time to hold the object
    private bool isCollected = false; // Ensure audio plays only once
    private float timer = 0f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = collectionSound;
    }

    void Update()
    {
        if (currentInteractor != null && !isCollected)
        {
            timer += Time.deltaTime;

            if (timer >= grabTime)
            {
                CollectItem();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object is grabbed by an XR Interactor
        if (other.TryGetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor>(out UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor interactor))
        {
            currentInteractor = interactor;
            timer = 0f; // Reset the timer when the object is grabbed
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Reset if the object is dropped
        if (other.TryGetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor>(out UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor interactor) && interactor == currentInteractor)
        {
            currentInteractor = null;
            timer = 0f;
        }
    }

    private void CollectItem()
    {
        isCollected = true;
        audioSource.Play(); // Play the collection sound

        // Optionally, disable further interactions
        GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>().enabled = false;
    }
}
