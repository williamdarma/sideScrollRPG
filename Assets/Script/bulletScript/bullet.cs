using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float damageAmount = 35f;
    [SerializeField] Vector3 moveVector = Vector3.zero;
    [SerializeField] Vector3 tempScale;
    [SerializeField] Vector3 defaultScale;
    [SerializeField] float defaultMoveSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        Invoke("offTimer", 4f);

    }
    private void OnDisable()
    {
        gameObject.transform.localScale = defaultScale;
        moveSpeed = defaultMoveSpeed;
    }
    public void SetDamage(float damage)
    {
        damageAmount = damage;
    }
    void offTimer()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        moveBullet();
    }

    private void moveBullet()
    {
        moveVector.x = moveSpeed * Time.deltaTime;
        transform.position += moveVector;
    }

    public void setNegativeSpeed()
    {
        moveSpeed *= -1f;
        tempScale = transform.localScale;
        tempScale.x = -tempScale.x;
        transform.localScale = tempScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagManager.enemy_Tag))
        {
            collision.GetComponent<enemyHealth>().takeDamage(damageAmount);
            gameObject.SetActive(false);
        }
    }
   
}
