using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    [SerializeField] Transform playerTarget;
    [SerializeField] float moveSpeed = 2;
    [SerializeField] Vector3 tempScale;
    [SerializeField] float stoppiingDistance = 1f;
    [SerializeField] playerAnimation enemyAnimation;

    Vector3 tempPos;
    [SerializeField] float minBound_Y = -2f, maxBound_Y = 2f, maxBound_X = 35f, minBound_X = -35f;

    [SerializeField] float attackWaitTime = 2f;
    [SerializeField] float attackTimer;
    [SerializeField] float attackFinishedWaitTime = .5f;
    [SerializeField] float attackFinishedTimer;
    [SerializeField] enemyDamageArea enemydamageArea;
    bool enemyDied;
    [SerializeField] RectTransform healthBarTransform;
    Vector3 healthBarTempScale;

    private void Awake()
    {
        enemyAnimation = GetComponent<playerAnimation>();
        playerTarget = GameObject.FindWithTag(tagManager.player_Tag).transform;
    }
    // Start is called before the first frame update
    void Start()
    {
 
    }
    // Update is called once per frame
    void Update()
    {


    }
    private void FixedUpdate()
    {
        if (enemyDied)
        {
            return;
        }
        searchForPlayer();
    }

    private void searchForPlayer()
    {
        if (!playerTarget)
        {
            return;
        }
        if (Vector3.Distance(transform.position, playerTarget.position)>stoppiingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTarget.position, moveSpeed * Time.deltaTime);
            tempPos = transform.position;
            if (tempPos.x < minBound_X)
            {
                tempPos.x = minBound_X;
            }
            if (tempPos.x > maxBound_X)
            {
                tempPos.x = minBound_X;
            }
            if (tempPos.y < minBound_Y)
            {
                tempPos.y = minBound_Y;
            }
            if (tempPos.y > maxBound_Y)
            {
                tempPos.y = maxBound_Y;
            }
            transform.position = tempPos;
            enemyAnimation.playAnimation(tagManager.walk_Animation_Name);
            handleFacingDirection();
        }
        else
        {
            checkIfAttackFinished();
            attack();
        }
    }

    void handleFacingDirection()
    {
        tempScale = transform.localScale;
        if (transform.position.x > playerTarget.position.x)
        {
            tempScale.x = -Mathf.Abs(tempScale.x);
        }
        else
        {
            tempScale.x = Mathf.Abs(tempScale.x);
        }

        transform.localScale = tempScale;
        //Health Bar Facing
        healthBarTempScale = healthBarTransform.localScale;
        if (transform.localScale.x>0)
        {
            healthBarTempScale.x = Mathf.Abs(healthBarTempScale.x);
        }
        else
        {
            healthBarTempScale.x = -Mathf.Abs(healthBarTempScale.x);
        }
        healthBarTransform.localScale = healthBarTempScale;
    }

    void checkIfAttackFinished()
    {
        if (Time.time>attackFinishedTimer)
        {
            enemyAnimation.playAnimation(tagManager.idle_Animation_Name);
        }
    }

    void attack()
    {
        if (Time.time > attackTimer)
        {
            attackFinishedTimer = Time.time + attackFinishedWaitTime;
            attackTimer = Time.time + attackWaitTime;
            enemyAnimation.playAnimation(tagManager.attack_Animation_Name);
        }
    }

  public  void EnemyAttack()
    {
        enemydamageArea.gameObject.SetActive(true);
        enemydamageArea.resetDeactivateTimer();
    }

    public void EnemyDied()
    {
        enemyDied = true;
        enemyAnimation.playAnimation(tagManager.death_Animation_Name);
        Invoke("destroyEnemyAfterDelay", 1.5f);
        gameController.instance.enemyKilled();
    }

    void destroyEnemyAfterDelay()
    {
        gameObject.SetActive(false);
    }
}
