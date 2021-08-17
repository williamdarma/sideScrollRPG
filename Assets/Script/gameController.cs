using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class gameController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI killedEnemytext;
    [SerializeField] int totalEnemyKilled = 0;
    public static gameController instance;

    private void Awake()
    {
        instance = this;
    }

    public void enemyKilled()
    {
        totalEnemyKilled += 1;
        changeText(totalEnemyKilled);
    }
    // Start is called before the first frame update
    void Start()
    {
        changeText(totalEnemyKilled);
    }

    void changeText(int value)
    {
        if (value == 5)
        {
            killedEnemytext.text = "Prototype Selesai";
        }
        else
        {
            killedEnemytext.text = "Enemy Killed: " + value.ToString();
        }
    }

    public void endGame()
    {
        killedEnemytext.text = "Prototype Selesai";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
