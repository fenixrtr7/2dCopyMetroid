using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rigid;
    public float speed = 6.0f;
    // Start is called before the first frame update
    void Start()
    {
        // Obtenemos el
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Si hacemos click en "UpArrow"
        // if (Input.GetKeyDown(KeyCode.UpArrow))
        // {
        //     Debug.Log("Go UP");

        //     rigid.AddForce(Vector3.forward * speed); // (x = 1 ,y = 0,z = 0)
        // }

        // Moviento para abajo
    }

    private void FixedUpdate() 
    {
        float moveHorizontal = Input.GetAxis ("Horizontal"); //  -1 <-> 1
        
        float moveVertical = Input.GetAxis ("Vertical"); //  -1 <-> 1

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rigid.AddForce (movement * speed);
    }
}

