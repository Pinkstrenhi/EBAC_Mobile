using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Vector2 previousPosition;
    public float velocity = 1f;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Move(Input.mousePosition.x - previousPosition.x);
        }

        previousPosition = Input.mousePosition;
    }

    public void Move(float speed)
    {
        transform.position += Vector3.right * (speed * velocity * Time.deltaTime);
    }
}
