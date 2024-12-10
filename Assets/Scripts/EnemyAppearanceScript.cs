using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAppearanceScript : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float disappearTime = 2.5f;
    private bool hasTriggered = false; // Ensures the enemy only appears once

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true; // Prevents further triggers
            enemy.SetActive(true);
            Invoke(nameof(HideEnemy), disappearTime);
        }
    }

    private void HideEnemy()
    {
        enemy.SetActive(false);
    }
}
