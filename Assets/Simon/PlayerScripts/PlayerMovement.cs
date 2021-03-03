using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
                     
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float moveForce = 5f;

    //Inputs
    private float moveVertical;
    private float moveHorizontal;
    void Start()
    {
    }

    void Update()
    {
        moveVertical = Input.GetAxis("Vertical");
        moveHorizontal = Input.GetAxis("Horizontal");

        transform.position += transform.right * moveHorizontal * moveForce * Time.deltaTime;
        transform.position += transform.forward * moveVertical * moveForce * Time.deltaTime;
    }
    private void BoolParameter(Animator animator, bool condition, string parameterName)
    {
        if (condition)
        {
            if (animator.GetBool(parameterName).Equals(false))
            {
                animator.SetBool(parameterName, true);
            }
        }
        else
        {
            if (animator.GetBool(parameterName).Equals(true))
            {
                animator.SetBool(parameterName, false);
            }
        }
    }
}
