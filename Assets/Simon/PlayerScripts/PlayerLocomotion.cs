using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    public Animator animator;
    float velocityZ = 0.0f;
    float velocityX = 0.0f;
    public float acceleration = 2.0f;
    public float deceleration = 2.0f;
    public float maximumWalkVelocity = 0.5f;
    public float maximumRunVelocity = 2.0f;
    int VelocityZHash;
    int VelocityXHash;
    int GunVelocityXHash;
    public bool forwardPressed;
    bool leftPressed;
    bool rightPressed;
    bool runPressed;
    bool backwardPressed;
    
    void Start()
    {
        VelocityZHash = Animator.StringToHash("VelocityZ");
        VelocityXHash = Animator.StringToHash("VelocityX");
        GunVelocityXHash = Animator.StringToHash("GunVelocityX");
    }
    void Update()
    {
        forwardPressed = Input.GetKey(KeyCode.W);   
        leftPressed = Input.GetKey(KeyCode.A);   
        rightPressed = Input.GetKey(KeyCode.D);
        runPressed = Input.GetKey(KeyCode.LeftShift);
        backwardPressed = Input.GetKey(KeyCode.S);

        float currentMaxVelocity = runPressed ? maximumRunVelocity : maximumWalkVelocity;


        if(forwardPressed && velocityZ < currentMaxVelocity)
        {
            velocityZ += Time.deltaTime * acceleration;
        } 
        if(leftPressed && velocityX > -currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * acceleration;
        }
        if(rightPressed && velocityX < currentMaxVelocity)
        {
            velocityX += Time.deltaTime * acceleration;
        }
        if (!forwardPressed && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * deceleration;
        }
        if (!backwardPressed && !forwardPressed && velocityZ < 0.0f)
        {
            velocityZ = 0.0f;
        }
        if (!leftPressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * deceleration;
        }
        if(!rightPressed && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * deceleration;
        }
        if(!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -0.05f && velocityX < 0.05f))
        {
            velocityX = 0.0f;
        }
        if(forwardPressed && runPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ = currentMaxVelocity;
        }
        else if( forwardPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ -= Time.deltaTime * deceleration;
            if(velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + 0.05f))
            {
                velocityZ = currentMaxVelocity;
            }
        }
        if(leftPressed && runPressed && velocityX < -currentMaxVelocity)
        {
            velocityX = -currentMaxVelocity;
        }
        else if ( leftPressed && velocityX < -currentMaxVelocity)
        {
            velocityX += Time.deltaTime * deceleration;
            if(velocityX < -currentMaxVelocity && velocityX > (-currentMaxVelocity - 0.05f))
            {
                velocityX = -currentMaxVelocity;
            }
        }
        else if( leftPressed && velocityX > -currentMaxVelocity && velocityX < (-currentMaxVelocity + 0.5f))
        {
            velocityX = -currentMaxVelocity;
        }
        if(rightPressed && runPressed && velocityX > currentMaxVelocity)
        {
            velocityX = currentMaxVelocity;
        }
        else if( rightPressed && velocityX > currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * deceleration;
            if(velocityX > currentMaxVelocity && velocityX < (currentMaxVelocity + 0.05f))
            {
                velocityX = currentMaxVelocity;
            }
        }
        else if(rightPressed && velocityX < currentMaxVelocity && velocityX > (currentMaxVelocity - 0.05f))
        {
            velocityX = currentMaxVelocity;
        }
        if (backwardPressed && velocityZ > -currentMaxVelocity)
        {
            velocityZ -= Time.deltaTime * deceleration;
            if (velocityZ > currentMaxVelocity && velocityZ > (currentMaxVelocity + 0.05f))
            {
                velocityZ = -currentMaxVelocity;
            }
        }
        animator.SetFloat(VelocityZHash, velocityZ);
        animator.SetFloat(VelocityXHash, velocityX);
        GunPosCorrectionX();
    }
    void GunPosCorrectionX()
    {
        //if (leftPressed || rightPressed)
        //{
        //    animator.SetLayerWeight(animator.GetLayerIndex("GunPosCorrectionX"), 1f);
        //    animator.Play("GunPosCorrectionX", animator.GetLayerIndex("GunPosCorrectionX"), VelocityXHash * velocityX);
        //}
        //else
        //{
        //    animator.SetLayerWeight(animator.GetLayerIndex("GunPosCorrectionX"), 1f);
        //}
    }
}
