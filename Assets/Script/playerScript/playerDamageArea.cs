using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDamageArea : MonoBehaviour
{
    [SerializeField] float deactivateWaitTime = .2f;
    [SerializeField] float deactivateTimer;

    [SerializeField] LayerMask enemyLayer;
    [SerializeField] float damageAmount = 50f;
    private bool canDealDamage;

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, 1f, enemyLayer))
        {
            if (canDealDamage)
            {
                canDealDamage = false;
               
                print("damage Player");
            }
        }
        deactivateDamageArea();
    }
    void deactivateDamageArea()
    {
        if (Time.time > deactivateTimer)
        {
            gameObject.SetActive(false);
        }
    }
    public void resetDeactivateTimer()
    {
        canDealDamage = true;
        deactivateTimer = Time.time + deactivateWaitTime;
    }
}
