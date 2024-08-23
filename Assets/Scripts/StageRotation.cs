using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageRotation : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 rotationVector;

    private void Update()
    {
        transform.Rotate(rotationVector * speed * Time.deltaTime);
    }
}
