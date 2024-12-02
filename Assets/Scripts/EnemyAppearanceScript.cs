using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAppearanceScript : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float disappearTime = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.SetActive(true);
            Invoke(nameof(HideEnemy), disappearTime);
        }
    }

    private void HideEnemy()
    {
        enemy.SetActive(false);
    }
}