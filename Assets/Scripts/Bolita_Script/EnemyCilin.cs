using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCilin : MonoBehaviour
{
    ManagerBolita managerBolita;

    private void Awake() {
        managerBolita = FindObjectOfType<ManagerBolita>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            // float num;
            // currentValue -= Time.deltaTime;
            
            managerBolita.GameOver();
        }
    }
}
