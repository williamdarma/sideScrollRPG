using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    playerMovement PlayerMovement;
    [SerializeField] UnityEngine.UI.Image healthBar;
    private void Awake()
    {
        PlayerMovement = GetComponent<playerMovement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takingDamage(float damage)
    {
        if (health<=0)
        {
            return;
        }
        health -= damage;
        Handheld.Vibrate();
        if (health<=0)
        {
            PlayerMovement.PlayerDied();
        }
        changeHealthBarValue(health);
    }

    private void changeHealthBarValue(float health)
    {
        healthBar.fillAmount = health / 100;
    }
}
