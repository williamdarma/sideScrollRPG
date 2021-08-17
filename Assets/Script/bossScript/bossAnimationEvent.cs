using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAnimationEvent : MonoBehaviour
{
    Boss b;
    private void Awake()
    {
        b = GetComponentInParent<Boss>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void bossAttack()
    {
        b.BosShoot();
    }
}
