using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUI : MonoBehaviour
{
    private bool Reloading;
    private float timer = 0.0f;
    private float rotationOffset = 0.0f;
    void Update()
    {
        if(KeyBoardManager.ReloadPressed())
        {
            Reloading = true;
        }
        else
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * 20f);
        }
        if(Reloading)
        {
            rotationOffset += Time.deltaTime * 2;
            timer += Time.deltaTime;
            transform.Rotate(Vector3.forward * Time.deltaTime * 50f * rotationOffset);
            if(timer > 5f)
            {
                Reloading = false;
                rotationOffset = 0.0f;
                timer = 0.0f;
            }
        }
    }
}
