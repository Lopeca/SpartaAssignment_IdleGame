using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFront : MonoBehaviour
{
    public float speed;
    private void FixedUpdate()
    {
        transform.position += Time.fixedDeltaTime * speed * transform.forward;
    }
}
