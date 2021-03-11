using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    [SerializeField] private GameObject body;
    void Start()
    {
        
    }
    void Update()
    {
        if(KeyBoardManager.CrouchPressed())
        {
            body.transform.position = -Vector3.up;
        }
        else
        {
            body.transform.position = Vector3.zero;
        }
    }
}
