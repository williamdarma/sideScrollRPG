using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamageArea : MonoBehaviour
{
    [SerializeField] float deactivateWaitTime = .2f;
    [SerializeField] float deactivateTimer;

    [SerializeField] LayerMask playerLayer;
    [SerializeField] float damageAmount = 50f;
    private bool canDealDamage;
    playerHealth _playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        _playerHealth = GameObject.FindWithTag(tagManager.player_Tag).GetComponent<playerHealth>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position,1f,playerLayer))
        {
            if (canDealDamage)
            {
                canDealDamage = false;
                _playerHealth.takingDamage(damageAmount);
                print("damage Player");
            }
        }
        deactivateDamageArea();
    }

    void deactivateDamageArea()
    {
        if (Time.time> deactivateTimer)
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
