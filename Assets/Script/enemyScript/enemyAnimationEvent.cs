using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAnimationEvent : MonoBehaviour
{
    enemy e;
    private void Awake()
    {
        e = GetComponentInParent<enemy>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void enemyAttack()
    {
        e.EnemyAttack();
    }
}
