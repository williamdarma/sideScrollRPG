using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 3;
    [SerializeField] float minBound_Y = -1f, maxBound_Y = 3f, maxBound_X = 35f,minBound_X = -35f;
    [SerializeField] float multiplier=1f;
    Vector3 tempPos;
    float xAxis, yAxis;

    playerAnimation player_Animation;
    playerShootingManager player_Shooting_Manager;

    [SerializeField] float attackWailtTime = .5f;
    [SerializeField] float waitBeforeAttack;
    [SerializeField] float moveWaitTime = .3f;
    [SerializeField] float waitBeforeMoving;
    bool canMove = true;
    bool isAttacking = false;
    bool playerDied;
    [SerializeField] FixedJoystick fj;
    [SerializeField] SpriteRenderer temp;

    // Start is called before the first frame update
    void Start()
    {
        player_Animation = GetComponent<playerAnimation>();
        player_Shooting_Manager = GetComponent<playerShootingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDied)
        {
            return;
        }
        handleMovement();
        handleAnimation();
        handleFacingDirection();

        handleAttacking();
        checkIfCanMove();
    }


    void handleMovement()
    {
        xAxis = Input.GetAxisRaw(tagManager.horizontal_Axis);
        yAxis = Input.GetAxisRaw(tagManager.vertical_Axis);
       // print(fj.Horizontal);
       //using joystick
      //  xAxis = fj.Horizontal;
       // yAxis = fj.Vertical;

        if (!canMove)
        {
            return;
        }

        tempPos = transform.position;

        tempPos.x += xAxis * moveSpeed * Time.deltaTime*multiplier;
        tempPos.y += yAxis * moveSpeed * Time.deltaTime*multiplier;

        if (tempPos.x <minBound_X)
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
    }

    void handleAnimation()
    {
        if (isAttacking)
        {
            return;
        }
        if (Mathf.Abs(xAxis)>0 || Mathf.Abs(yAxis)>0)
        {

            player_Animation.playAnimation(tagManager.walk_Animation_Name);
        }
        else
        {
            player_Animation.playAnimation(tagManager.idle_Animation_Name);
        }
    }

    void handleFacingDirection()
    {
        if (xAxis>0)
        {
            player_Animation.setFacingDirection(true);
        }
        else if (xAxis<0)
        {
            player_Animation.setFacingDirection(false);
        }
    }

    public void Attack()
    {
        if (Time.time > waitBeforeAttack)
        {
            waitBeforeAttack = Time.time + attackWailtTime;
            isAttacking = true;
            stopMovement();
            player_Animation.playAnimation(tagManager.attack_Animation_Name);
        }
    }

    public void playerShoot()
    {
        player_Shooting_Manager.Shoot(transform.localScale.x);
    }

    void stopMovement()
    {
        canMove = false;
        waitBeforeMoving = Time.time + moveWaitTime;
    }
    void checkIfCanMove()
    {
        if (Time.time> waitBeforeMoving)
        {
            canMove = true;
            isAttacking = false;
        }
    }
    void handleAttacking()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
          //  if (Time.time> waitBeforeAttack)
            //{
                Attack();
           // }
        }
    }

    public void PlayerDied()
    {
        playerDied = true;
        player_Animation.playAnimation(tagManager.death_Animation_Name);
        gameController.instance.endGame();
        Invoke("destroyEnemyAfterDelay", 1.5f);
    }
    void destroyEnemyAfterDelay()
    {
        gameObject.SetActive(false);
    }
}
