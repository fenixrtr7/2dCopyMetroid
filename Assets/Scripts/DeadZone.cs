using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy")) // Si choca "Player" o "Enemy"
        {
            Destroy(other.gameObject); // Destruir
        }
    }
}
