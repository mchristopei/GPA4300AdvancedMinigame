using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPivot : MonoBehaviour
{
    [SerializeField] private GameObject positionParent;

    private Vector3 positionOffset;
    [SerializeField] private float xPositionOffset;
    [SerializeField] private float yPositionOffset;
    [SerializeField] private float zPositionOffset;

    private Quaternion rotationOffset;
    [SerializeField] private float xRotationOffset = 1f;
    [SerializeField] private float yRotationOffset = 1f;
    [SerializeField] private float zRotationOffset = 1f;
    void Start()
    {
        
    }
    void Update()
    {
        rotationOffset = new Quaternion(xRotationOffset, yRotationOffset, zRotationOffset, 1);
        positionOffset = new Vector3(xPositionOffset, yPositionOffset, zPositionOffset);
    }
}
