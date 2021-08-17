using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] float health = 2000f;
    [SerializeField] UnityEngine.UI.Image healthBar;
    [SerializeField] Boss bossScript;
    private void Awake()
    {
        bossScript = GetComponent<Boss>();
    }

    public void takeDamage(float damage)
    {
        if (health <= 0)
        {
            return;
        }

        health -= damage;
        if (health <= 0)
        {
            health = 0;
            //enemy death
            bossScript.BossDied();
        }
        changeHealthBarValue(health);
    }
    void changeHealthBarValue(float value)
    {
        healthBar.fillAmount = value / 100;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
