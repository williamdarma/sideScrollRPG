using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimationEvent : MonoBehaviour
{
    playerMovement pm;
    private void Awake()
    {
        pm = GetComponentInParent<playerMovement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerAttack()
    {
        pm.playerShoot() ;
    }
}
