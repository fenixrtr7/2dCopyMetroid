using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCube : MonoBehaviour
{
    public ManagerBolita managerBolita;
    //public int value = 1; 
    // Start is called before the first frame update
    void Start()
    {
        //uIManager = FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        // Si chocamos con el objeto con tag player
        if(collision.CompareTag("Player"))
        {
            managerBolita.AddPoints();

            // Destruir objeto
            Destroy(this.gameObject);
        }
    }
}
