using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUI : MonoBehaviour
{
    private bool Reloading;
    private float timer = 0.0f;
    private float rotationOffset = 0.0f;
    private KeyBoardManager keyBoardManager;

    private void Start()
    {
        keyBoardManager = FindObjectOfType<KeyBoardManager>();
    }
    void Update()
    {
        if(keyBoardManager.ReloadPressed())
        {
            Reloading = true;
        }

        if(Reloading)
        {
            timer += Time.deltaTime;
            if(timer < 3.0f)
            {
                rotationOffset += Time.deltaTime * 3;
                transform.Rotate(Vector3.forward * Time.deltaTime * 50f * rotationOffset);
            }
            if(timer > 3.0f && timer < 6f)
            {
                rotationOffset -= Time.deltaTime * 9;
                transform.Rotate((Vector3.forward * Time.deltaTime * 50f) *rotationOffset);
            }
            if (timer > 4.0f)
            {
                Reloading = false;
                rotationOffset = 0.0f;
                timer = 0.0f;
            }
        }
        else
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * 30f);

        }
    }
}
