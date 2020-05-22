using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerBolita : MonoBehaviour
{
    int currentPoints = 0;
    //int valueTotal;

    // GameObject[] myList;

    public GameObject canvasWin, canvasLose, canvasPause;

    public Text textPoints; 

    bool isPause = false;

    // Start is called before the first frame update
    void Start()
    {
        // myList = GameObject.FindGameObjectsWithTag("Collectable");
        textPoints.text = "Points: " + currentPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints()
    {
        currentPoints++;
        textPoints.text = "Points: " + currentPoints;

        if(currentPoints >= 3)
        {
            // Activar pantalla de win
            canvasWin.SetActive(true);

            // Cargar la escena y mostrar el win
            //SceneManager.LoadScene(1);
        }
    }

    public void GameOver()
    {
        canvasLose.SetActive(true);
        Time.timeScale = 0;
    }

    public void Pause()
    {
        if (isPause)
        {
            isPause = false;

            Time.timeScale = 1;
            canvasPause.SetActive(false);
        }else
        {
            isPause = true;

            Time.timeScale = 0;
            canvasPause.SetActive(true);
        }
    }
}
