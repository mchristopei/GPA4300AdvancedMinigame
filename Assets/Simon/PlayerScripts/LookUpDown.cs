using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUpDown : MonoBehaviour
{
    private float moveVertical;
    private float moveHorizontal;

    private float lookUpDownAngle = 0f;

    private float CamposTime;
    private float timeOffset;
    [SerializeField] private float mouseSensitivityX = 0.01f;
    [SerializeField] private float mouseSensitivity = 100f;
    private bool isAiming;
    [SerializeField] new private Camera camera;
    [SerializeField] private Animator animator;
    void Start()
    {
        LockMouse();
        timeOffset = 0f;
    }
    void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;
        lookUpDownAngle -= mouseY;
        timeOffset += -mouseY * mouseSensitivityX;

        if (timeOffset >= 1.0f)
        {
            timeOffset = 1.0f;
        }
        if (timeOffset <= -1.0f)
        {
            timeOffset = -1.0f;
        }
        animator.SetFloat("VelocityY", timeOffset);
        transform.Rotate(Vector3.up * mouseX);
    }
}
