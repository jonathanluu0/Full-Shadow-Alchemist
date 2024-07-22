using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    //References
    Animator am;
    PlayerMovement pm;
    SpriteRenderer sr;


    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        // player anim updates from idle to moving if moveDir != 0
        if (pm.moveDir.x != 0 || pm.moveDir.y != 0)
        {
            am.SetBool("Move", true);
            SpriteDirectionChecker();
        } else {
            am.SetBool("Move", false);
        }
    }

    // flips player direction based on A/D movement
    void SpriteDirectionChecker()
    {
        if(pm.lastHorizontalVector < 0)
        {
            sr.flipX = true;
        } else {
            sr.flipX = false;
        }
    }
}
