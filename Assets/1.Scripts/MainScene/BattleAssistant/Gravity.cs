using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] CharacterController characterController;

    private void Awake()
    {
        if (!characterController)
        {
            characterController = GetComponent<CharacterController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        characterController.Move(Time.deltaTime * Physics.gravity);
    }
}
