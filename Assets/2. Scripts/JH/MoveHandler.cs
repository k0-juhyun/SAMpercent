using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHandler : MonoBehaviour
{
    public float moveSpeed;
    void Start()
    {

    }

    void FixedUpdate()
    {
        float V = Input.GetAxis("Vertical");
        float H = Input.GetAxis("Horizontal");

        Vector3 moveDirection = new Vector3(V, 0, -H);
        moveDirection.Normalize();
        transform.position += moveDirection * moveSpeed;
    }
}
