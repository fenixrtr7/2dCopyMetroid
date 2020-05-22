using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploArray : MonoBehaviour
{
    public int[] ejemploArray = new int[10];
    int sumaTotal = 0;

    private void Start() 
    {
        
        for (int i = 0; i < ejemploArray.Length; i++) // = 10
        {
            sumaTotal += ejemploArray[i]; 
        }

        //Debug.Log("La suma total es: " + sumaTotal);

        
        /////////////////////////////////////////
        // Foreach
        /////////////////////////////////////////
        var sumaDelForeach = 0;

        foreach (var elentoDelArray in ejemploArray)
        {
            sumaDelForeach += elentoDelArray;
        }

        //Debug.Log("La suma total usando 'Foreach' es: " + sumaDelForeach);
    }

    public void CualquierOtroMetodo()
    {
        Debug.Log("La suma total es: " + sumaTotal);
    }
}
