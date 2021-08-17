using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Vector3 tempScale;
    [SerializeField] int currentAnimation;


    private void Awake()
    {
        //anim = GetComponent<Animator>();
    }

    public void playAnimation(string animationName)
    {
        if (currentAnimation == Animator.StringToHash(animationName))
        {
            return;
        }
        anim.Play(animationName);
        currentAnimation = Animator.StringToHash(animationName);
    }

    public void setFacingDirection(bool faceRight)
    {
        tempScale = transform.localScale;
        if (faceRight)
        {
            tempScale.x = 2f;
        }
        else
        {
            tempScale.x = -2f;
        }
        transform.localScale = tempScale;
    }

}
