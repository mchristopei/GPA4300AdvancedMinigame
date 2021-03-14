using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Animator animator;
                     
    [SerializeField] private float moveForce = 5f;
    private float initMoveForce;
    [SerializeField] private float runForce = 10f;
    private bool isGrounded;

    //Inputs
    private float moveVertical;
    private float moveHorizontal;
    void Start()
    {
        initMoveForce = moveForce;
    }

    void Update()
    {
        moveVertical = Input.GetAxis("Vertical");
        moveHorizontal = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(moveForce < runForce)
            {
                moveForce += Time.deltaTime;
            }
            else if(moveForce > runForce)
            {
                moveForce = runForce;
            }
        }
        else
        {
            if(moveForce > initMoveForce)
            {
                moveForce = initMoveForce;
            }
        }
        transform.position += transform.right * moveHorizontal * moveForce * Time.deltaTime;
        transform.position += transform.forward * moveVertical * moveForce * Time.deltaTime;
    }
}
