using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterSet controller;
    public string axisHorizontal, commandJump;

    void Start()
    {
        controller = this.GetComponent<CharacterSet>();
    }

    void Update()
    {
        controller.Move(Input.GetAxis(axisHorizontal));

        if (Input.GetButtonDown(commandJump))
        {
            controller.Jump();
        }
    }
}
