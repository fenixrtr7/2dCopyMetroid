using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    int collectableP = 0;
    [SerializeField] private Text textCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textCount.text = "x " + collectableP;
    }

    public void AddPoints(int amount)
    {
        collectableP += amount; // collectable = colectable + amount
    }
}
