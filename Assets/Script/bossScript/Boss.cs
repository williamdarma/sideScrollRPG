using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] Transform playerTarget;
    [SerializeField] float moveSpeed = 2;
    [SerializeField] Vector3 tempScale;
    [SerializeField] float stoppiingDistance = 8f;

    [SerializeField] float attackWaitTime = 2f;
    [SerializeField] float attackTimer;
    [SerializeField] float attackFinishedWaitTime = .5f;
    [SerializeField] float attackFinishedTimer;

    [SerializeField] playerAnimation bossAnimation;
    [SerializeField] BossShootingManager _bossShootingManager;
    bool bossDied;
    private void Awake()
    {
        bossAnimation = GetComponent<playerAnimation>();
        playerTarget = GameObject.FindWithTag(tagManager.player_Tag).transform;
        _bossShootingManager = GetComponent<BossShootingManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bossDied)
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
        if (Vector3.Distance(transform.position, playerTarget.position) > stoppiingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTarget.position, moveSpeed * Time.deltaTime);
            bossAnimation.playAnimation(tagManager.walk_Animation_Name);

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
    }

    void checkIfAttackFinished()
    {
        if (Time.time > attackFinishedTimer)
        {
            bossAnimation.playAnimation(tagManager.idle_Animation_Name);
        }
    }

    void attack()
    {
        if (Time.time > attackTimer)
        {
            attackFinishedTimer = Time.time + attackFinishedWaitTime;
            attackTimer = Time.time + attackWaitTime;
            bossAnimation.playAnimation(tagManager.attack_Animation_Name);
        }
    }

    public void BossDied()
    {
        bossDied = true;
        bossAnimation.playAnimation(tagManager.death_Animation_Name);
        Invoke("destroyEnemyAfterDelay", 1.5f);
    }

    void destroyEnemyAfterDelay()
    {
        gameObject.SetActive(false);
    }

    public void BosShoot()
    {
        _bossShootingManager.Shoot(transform.localScale.x);
    }
}
