using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerTarget;
    [SerializeField] float smoothSpeed;
    [SerializeField] float playerBoundMin_Y = -1f, playerBoundMin_X = -26f, playerBoundMax_X = 26f;
    [SerializeField] float y_Gap = 2f;
    Vector3 tempPos;
    // Start is called before the first frame update
    void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag(tagManager.player_Tag).transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void LateUpdate()
    {
        moveCamera();
    }

    void moveCamera()
    {
        if (!playerTarget)
        {
            return;
        }
        tempPos = transform.position;
        tempPos = Vector3.Lerp(transform.position, new Vector3 (playerTarget.position.x,1,-10), Time.deltaTime * smoothSpeed);
        if (tempPos.x > playerBoundMax_X)
        {
            tempPos.x = playerBoundMax_X;
        }
        if (tempPos.x<playerBoundMin_X)
        {
            tempPos.x = playerBoundMin_X;
        }
        transform.position = tempPos;
    }
}
