using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetGroundCheck : MonoBehaviour
{
    public bool isGrounded;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Ground"))
        {
            isGrounded = false;
        }
    }
}
