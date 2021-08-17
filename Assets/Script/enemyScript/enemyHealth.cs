using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
   [SerializeField] UnityEngine.UI.Image healthBar;
    enemy enemyScript;
    private void Awake()
    {
        enemyScript = GetComponent<enemy>();
    }

    public void takeDamage( float damage)
    {
        if (health<=0)
        {
            return;
        }

        health -= damage;
        if (health<=0)
        {
            health = 0;
            //enemy death
            enemyScript.EnemyDied();
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
