using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsTest : MonoBehaviour
{
    public Animator torso;
    public Animator legs;

    public bool onGround;

    // Update is called once per frame
    void Update()
    {
        // Change the onground animation
        ChangeTorsoAnimation("onGround", onGround);
        ChangeLegsAnimation("onGround", onGround);

        // Change the running animation
        if (Input.GetAxis("Horizontal") != 0)
        {
            ChangeTorsoAnimation("isRunning", true);
            ChangeLegsAnimation("isRunning", true);
        }
        else
        {
            ChangeTorsoAnimation("isRunning", false);
            ChangeLegsAnimation("isRunning", false);
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            // For crouching
            if (onGround)
            {
                ChangeTorsoAnimation("isCrouching", true);
                ChangeLegsAnimation("isCrouching", true);
            }
            // For Aiming down in the air
            else if (!onGround)
            {
                ChangeTorsoAnimation("isCrouching", true);
                ChangeLegsAnimation("isCrouching", false);
            }
        }
        else
        {
            ChangeTorsoAnimation("isCrouching", false);
            ChangeLegsAnimation("isCrouching", false);
        }

        // For aiming up
        if (Input.GetAxis("Vertical") > 0)
        {
            ChangeTorsoAnimation("aimingUp", true);
        }
        else
        {
            ChangeTorsoAnimation("aimingUp", false);
        }
    }

    // For changing torso animations
    void ChangeTorsoAnimation(string action, bool value)
    {
        torso.SetBool(action, value);
    }

    // For changing legs animations
    void ChangeLegsAnimation(string action, bool value)
    {
        legs.SetBool(action, value);
    }
}
